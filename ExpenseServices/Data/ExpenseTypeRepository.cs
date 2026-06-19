
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using ExpenseServices.DTOs;
using ExpenseServices.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ExpenseServices.Data {
    public class ExpenseTypeRepository:Repository<ExpenseType> {

        private readonly DbSet<ExpenseType> _set;

        public ExpenseTypeRepository(ExpenseContext context) : base(context) {
            _set = context.ExpenseTypes;
        }

        /// <summary>
        /// Returns the entity
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The entity</returns>
        public async Task<ExpenseType?> GetEntity(int id) {
            return await _set.FirstOrDefaultAsync(et => et.Id == id);
        }

        /// <summary>
        /// Returns the Expense Types
        /// </summary>
        /// <returns>A collection of types</returns>
        public async Task<IEnumerable<ExpenseTypeDto>> GetTypes() {
            return await _set.Select(et => new ExpenseTypeDto(et.Id, et.Name)).ToListAsync();
        }

        /// <summary>
        /// Validates the existace of a type
        /// </summary>
        /// <param name="name">The type name</param>
        /// <returns>The Id of the entity or 0 if it doesn't</returns>
        public async Task<int> Exists(string name) {
            return await _set.Where(t => EF.Functions.Collate(t.Name,"NOCASE") == name).Select(t => t.Id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns the group types for the report form
        /// </summary>
        /// <param name="from">The starting date to filter expenses</param>
        /// <param name="to">The end date to filter expenses</param>
        /// <returns>A collection of ExpenseTypeGroupDto</returns>
        public async Task<IEnumerable<ExpenseTypeGroupDto>> GetTypesGroup(DateTime? from, DateTime? to) {
            bool filter = from.HasValue || to.HasValue;
            bool doubleFilter = from.HasValue && to.HasValue;
            var parameters = new List<object>();
            string query = $@"SELECT t.Name, COUNT(*) as Count, Sum(e.Cost) as Total " +
                "FROM Types t " +
                "INNER JOIN Expenses e ON t.Id = e.TypeId";
            if (filter) {
                query += $@" WHERE ";
                if (from.HasValue) {
                    query += $@" e.Date >= @From ";
                    parameters.Add(new SqliteParameter("@From", from));
                }
                if (to.HasValue) {
                    if (doubleFilter) {
                        query += $@" AND ";
                    }
                    query += $@"e.Date <= @To ";
                    parameters.Add(new SqliteParameter("@To", to));
                }
            }
            query += " GROUP BY t.Name ";
            return await _context.Database.SqlQueryRaw<ExpenseTypeGroupDto>(query, parameters.ToArray())
                .OrderByDescending(et => et.Total)
                .ThenBy(et => et.Name)
                .ToListAsync();
        }

    }
}

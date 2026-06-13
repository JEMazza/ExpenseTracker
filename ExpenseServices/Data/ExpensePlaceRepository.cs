
using DocumentFormat.OpenXml.Spreadsheet;
using ExpenseServices.DTOs;
using ExpenseServices.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ExpenseServices.Data {
    public class ExpensePlaceRepository:Repository<ExpensePlace> {

        private readonly DbSet<ExpensePlace> _set;
        public ExpensePlaceRepository(ExpenseContext context) : base(context) {
            _set = context.ExpensePlaces;
        }

        /// <summary>
        /// Returns full entity
        /// </summary>
        /// <param name="id">Entity searched</param>
        /// <returns>Either the Place or null</returns>
        public async Task<ExpensePlace?> GetEntity(int id) {
            return await _set.FirstOrDefaultAsync(et => et.Id == id);
        }

        /// <summary>
        /// Returns all places
        /// </summary>
        /// <returns>A collection of ExpensePlaceDto</returns>
        public async Task<IEnumerable<ExpensePlaceDto>> GetPlaces() {
            return await _set.Select(et => new ExpensePlaceDto(et.Id, et.Name)).ToListAsync();
        }

        /// <summary>
        /// Validates the existance of a place BY id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<int> Exists(string name) {
            return await _set.Where(p => EF.Functions.Collate(p.Name,"NOCASE") == name).Select(p => p.Id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<List<ExpensePlaceGroupDto>> GetPlacesGroup(DateTime? from, DateTime? to) {
            bool filter = from.HasValue || to.HasValue;
            bool doubleFilter = from.HasValue && to.HasValue;
            var parameters = new List<object>();
            string query = $@"SELECT p.Name, COUNT(*) as Count, Sum(e.Cost) as Total " +
                "FROM Places p " +
                "INNER JOIN Expenses e ON p.Id = e.PlaceId";
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
            query += " GROUP BY p.Name ";
            return await _context.Database.SqlQueryRaw<ExpensePlaceGroupDto>(query, parameters.ToArray())
                .OrderByDescending(et => et.Total)
                .ThenBy(et => et.Name)
                .ToListAsync();
        }

    }
}

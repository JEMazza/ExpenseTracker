
using ExpenseServices.DTOs;
using ExpenseServices.Entities;
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
            return await _set.Where(t => t.Name == name).Select(t => t.Id).FirstOrDefaultAsync();
        }
    }
}

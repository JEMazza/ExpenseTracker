
using ExpenseServices.DTOs;
using ExpenseServices.Entities;
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
            return await _set.Where(p => p.Name == name).Select(p => p.Id).FirstOrDefaultAsync();
        }
    }
}

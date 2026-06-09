
using ExpenseServices.DTOs;
using ExpenseServices.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseServices.Data {
    public class ExpenseRepository : Repository<Expense> {

        public readonly DbSet<Expense> _set;

        public ExpenseRepository(ExpenseContext context) : base(context) {
            _set = context.Expenses;
        }

        /// <summary>
        /// Returns the entity
        /// </summary>
        /// <param name="id">Id of the entity to be returned</param>
        /// <returns>The full entity</returns>
        public async Task<Expense?> GetEntity(int id) {
            return await _set.Include(e => e.Place).Include(e => e.Type).FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Extracted method for basic DTO querying
        /// </summary>
        /// <param name="from">The date to filter from</param>
        /// <param name="to">The date to filter to</param>
        /// <param name="types">The types to filter</param>
        /// <param name="places">The places to filter</param>
        /// <returns>The base query with all filters applied</returns>
        private IQueryable<Expense> GetBaseQuery(DateTime? from, DateTime? to, IEnumerable<int> types, IEnumerable<int> places) {
            var query = _set.AsQueryable();
            if (from.HasValue) {
                query = query.Where(e => e.Date >= from);
            }
            if (to.HasValue) {
                query = query.Where(e => e.Date <= to);
            }
            if (types != null && types.Any()) {
                query = query.Where(e => types.Contains(e.TypeId));
            }
            if (places != null && places.Any()) {
                query = query.Where(e => places.Contains(e.PlaceId));
            }
            return query;
        }

        /// <summary>
        /// Returns the ExpenseDtos
        /// </summary>
        /// <param name="from">The date to filter from</param>
        /// <param name="to">The date to filter to</param>
        /// <param name="types">The types to filter</param>
        /// <param name="places">The places to filter</param>
        /// <param name="page">The page</param>
        /// <param name="size">The size of the page</param>
        /// <param name="order">The order of the dtos</param>
        /// <returns>A collection of ExpenseDto</returns>
        public async Task<IEnumerable<ExpenseDto>> GetExpenses(DateTime? from, DateTime? to, IEnumerable<int> types, IEnumerable<int> places, int? page, int? size, ExpenseOrderEnum order = ExpenseOrderEnum.OrderByDate) {
            var query = GetBaseQuery(from, to, types, places);
            query = order switch {
                ExpenseOrderEnum.OrderByDate => query.OrderBy(e => e.Date).ThenBy(e => e.Id),
                ExpenseOrderEnum.OrderByDateDesc => query.OrderByDescending(e => e.Date).ThenByDescending(e => e.Id),
                ExpenseOrderEnum.OrderByName => query.OrderBy(e => e.Name).ThenBy(e => e.Id),
                ExpenseOrderEnum.OrderByNameDesc => query.OrderByDescending(e => e.Name).ThenByDescending(e => e.Id),
                ExpenseOrderEnum.OrderByCost => query.OrderBy(e => e.Cost).ThenBy(e => e.Id),
                ExpenseOrderEnum.OrderByCostDesc => query.OrderByDescending(e => e.Cost).ThenByDescending(e => e.Id),
                _ => query.OrderBy(e => e.Id)
            };
            if (page.HasValue && size.HasValue) {
                query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
            }
            return await query.Select(e => new ExpenseDto(
                    e.Id,
                    e.Name,
                    e.Date.ToString("dd-MM-yyyy"),
                    e.Cost,
                    e.Type.Name,
                    e.Place.Name)
                ).ToListAsync();
        }

        /// <summary>
        /// A summary of the expense list
        /// </summary>
        /// <param name="from">The date to filter from</param>
        /// <param name="to">The date to filter to</param>
        /// <param name="types">The types to filter</param>
        /// <param name="places">The places to filter</param>
        /// <returns>The summary containing the total, the ammount of expenses, the highest place and type</returns>
        public async Task<ExpenseSummaryDto> GetSummary(DateTime? from, DateTime? to, IEnumerable<int> types, IEnumerable<int> places) {
            var query = GetBaseQuery(from, to, types, places);
            var highPlace = await query.GroupBy(ex => ex.Place.Name).OrderByDescending(exp => exp.Sum(ex => ex.Cost)).Select(exp => exp.Key).FirstOrDefaultAsync() ?? "N/A";
            var highType = await query.GroupBy(ex => ex.Type.Name).OrderByDescending(exp => exp.Sum(ex => ex.Cost)).Select(exp => exp.Key).FirstOrDefaultAsync() ?? "N/A";
            return new ExpenseSummaryDto(await query.SumAsync(ex => ex.Cost),await query.CountAsync(),highPlace,highType);
        }

        /// <summary>
        /// Searches the existance of an expense based on an ID
        /// </summary>
        /// <param name="id">The entity ID</param>
        /// <returns>The ExpenseDto</returns>
        public async Task<ExpenseFormDto?> GetExpense(int id) {
            return await _set.Where(e => e.Id == id).Select(ex => new ExpenseFormDto(
                ex.Id,
                ex.Name,
                ex.Date,
                ex.Cost,
                ex.TypeId,
                ex.PlaceId)
            ).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns the ammount of expenses based on the filter
        /// </summary>
        /// <param name="from">The starting date of the expenses</param>
        /// <param name="to">The final date of the expenses</param>
        /// <param name="types">The expense types</param>
        /// <param name="places">The expense places</param>
        /// <returns>The ammount of expenses based on the filter</returns>
        public async Task<int> GetExpenseCount(DateTime? from, DateTime? to, IEnumerable<int> types, IEnumerable<int> places) {
            var query = GetBaseQuery(from, to, types, places);
            return await query.CountAsync();
        }

        public async Task<IEnumerable<ExpenseChartDto>> GetTop5Dates(DateTime? from, DateTime? to, IEnumerable<int> types, IEnumerable<int> places) {
            var query = GetBaseQuery(from, to, types, places);
            return await query.GroupBy(ex => ex.Date)
                .OrderByDescending(g => g.Sum(ex => ex.Cost))
                .Take(5)
                .Select(g => new ExpenseChartDto(g.Key.ToString("yyyy-MM-dd"), g.Sum(ex => ex.Cost)))
                .ToListAsync();
        }
    }
}

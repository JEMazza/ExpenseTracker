
using ExpenseServices.Data;
using ExpenseServices.DTOs;

namespace ExpenseServices.Services {
    public class ExpensePlaceService:BaseService {
        public ExpensePlaceService(ExpensesUnitOfWork unit) : base(unit) {
        }

        /// <summary>
        /// Gets the expense places
        /// </summary>
        /// <returns>A collection of ExpensePlaceDto</returns>
        public async Task<IEnumerable<ExpensePlaceDto>> GetPlaces() {
            return await _unit.ExpensePlace.GetPlaces();
        }


        /// <summary>
        /// Gets the expense type summary
        /// </summary>
        /// <param name="from">The start date of the expenses</param>
        /// <param name="to">The end date of the expenses</param>
        /// <returns>A collection of ExpenseTypeGroupDto</returns>
        public async Task<IEnumerable<ExpensePlaceGroupDto>> GetPlaceSummary(DateTime? from, DateTime? to) {
            return await _unit.ExpensePlace.GetPlacesGroup(from,to);
        }
    }
}


using ExpenseServices.Data;
using ExpenseServices.DTOs;

namespace ExpenseServices.Services {
    public class ExpensePlaceService:BaseService {
        public ExpensePlaceService(ExpensesUnitOfWork unit) : base(unit) {
        }

        public async Task<IEnumerable<ExpensePlaceDto>> GetPlaces() {
            return await _unit.ExpensePlace.GetPlaces();
        }

    }
}

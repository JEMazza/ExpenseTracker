
using ExpenseServices.Data;
using ExpenseServices.DTOs;

namespace ExpenseServices.Services {
    public class ExpenseTypeService : BaseService {
        public ExpenseTypeService(ExpensesUnitOfWork unit) : base(unit) {
        }

        public async Task<IEnumerable<ExpenseTypeDto>> GetTypes() {
            return await _unit.ExpenseTypes.GetTypes();
        }
    }
}


using ExpenseServices.Data;
using ExpenseServices.DTOs;

namespace ExpenseServices.Services {
    public class ExpenseTypeService : BaseService {
        public ExpenseTypeService(ExpensesUnitOfWork unit) : base(unit) {
        }

        public async Task<IEnumerable<ExpenseTypeDto>> GetTypes() {
            return await _unit.ExpenseTypes.GetTypes();
        }

        public async Task<IEnumerable<ExpenseTypeGroupDto>> GetTypesSummary(DateTime? from,DateTime? to) {
            return await _unit.ExpenseTypes.GetTypesGroup(from, to);
        }
    }
}

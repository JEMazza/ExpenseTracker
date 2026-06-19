
using ExpenseServices.Data;
using ExpenseServices.DTOs;

namespace ExpenseServices.Services {
    public class ExpenseTypeService : BaseService {
        public ExpenseTypeService(ExpensesUnitOfWork unit) : base(unit) {
        }

        /// <summary>
        /// Gets the expense types
        /// </summary>
        /// <returns>A collection of ExpenseTypeDto</returns>
        public async Task<IEnumerable<ExpenseTypeDto>> GetTypes() {
            return await _unit.ExpenseTypes.GetTypes();
        }


        /// <summary>
        /// Gets the expense type summary
        /// </summary>
        /// <param name="from">The start date of the expenses</param>
        /// <param name="to">The end date of the expenses</param>
        /// <returns>A collection of ExpenseTypeGroupDto</returns>
        public async Task<IEnumerable<ExpenseTypeGroupDto>> GetTypesSummary(DateTime? from,DateTime? to) {
            return await _unit.ExpenseTypes.GetTypesGroup(from, to);
        }
    }
}

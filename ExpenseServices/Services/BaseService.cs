
using ExpenseServices.Data;

namespace ExpenseServices.Services {
    public abstract class BaseService {

        protected readonly ExpensesUnitOfWork _unit;

        protected BaseService(ExpensesUnitOfWork unit) {
            _unit = unit;
        }
    }
}

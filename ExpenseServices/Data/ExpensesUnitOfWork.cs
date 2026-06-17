using ExpenseServices.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace ExpenseServices.Data {
    public class ExpensesUnitOfWork : IUnitOfWork {

        private ExpenseContext _context { get; set; }

        private ExpenseRepository? _expenses { get; set; }
        private ExpenseTypeRepository? _expenseTypes { get; set; }
        private ExpensePlaceRepository? _expensePlaces { get; set; }
        public ExpensesUnitOfWork(ExpenseContext context) {
            _context = context;
        }
        
        /// <summary>
        /// Returns the expense repository or creates it if it hasn't.
        /// </summary>
        public ExpenseRepository Expenses => _expenses??= new ExpenseRepository(_context);
        /// <summary>
        /// Returns the expense type repository or creates it if it hasn't.
        /// </summary>
        public ExpenseTypeRepository ExpenseTypes => _expenseTypes ??= new ExpenseTypeRepository(_context);
        /// <summary>
        /// Returns the expense place repository or creates it if it hasn't.
        /// </summary>
        public ExpensePlaceRepository ExpensePlace => _expensePlaces ??= new ExpensePlaceRepository(_context);

        public async Task Save() {
            await _context.SaveChangesAsync();
        }

        public async Task Commit(IDbContextTransaction tran) {
            await tran.CommitAsync();
        }

        public async Task Rollback(IDbContextTransaction tran) {
            await tran.RollbackAsync();
        }

        public async Task<IDbContextTransaction> StartTransaction() {
            return await _context.Database.BeginTransactionAsync();
        }

    }
}

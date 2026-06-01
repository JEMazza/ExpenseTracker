
using Microsoft.EntityFrameworkCore.Storage;

namespace ExpenseServices.Data {
    public interface IUnitOfWork{

        /// <summary>
        /// Commits a transaction
        /// </summary>
        /// <param name="tran">The transaction to be commited</param>
        /// <returns>Nothing</returns>
        public Task Commit(IDbContextTransaction tran);

        /// <summary>
        /// Rolls back a transaction
        /// </summary>
        /// <param name="tran">The transaction to be rolled back</param>
        /// <returns>Nothing</returns>
        public Task Rollback(IDbContextTransaction tran);

        /// <summary>
        /// Calls SaveChangesAsync()
        /// </summary>
        /// <returns>Nothing</returns>
        public Task Save();
        /// <summary>
        /// Starts a transaction
        /// </summary>
        /// <returns>The transaction to be used</returns>
        public Task<IDbContextTransaction> StartTransaction();
    }
}

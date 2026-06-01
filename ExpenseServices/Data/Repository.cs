using ExpenseServices.Entities;

namespace ExpenseServices.Data {
    public abstract class Repository<TEntity> : IRepository<TEntity> {

        protected readonly ExpenseContext _context;

        public Repository(ExpenseContext context) {
            _context = context;
        }

        /// <summary>
        /// Adds an entity
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns></returns>
        public async Task Add(TEntity entity) {
            await _context.AddAsync(entity);
        }

        /// <summary>
        /// Removes an entity
        /// </summary>
        /// <param name="entity">The entity to remove</param>
        public void Delete(TEntity entity) {
            _context.Remove(entity);
        }
    }
}


namespace ExpenseServices.Data {
    internal interface IRepository<TEntity>{

        /// <summary>
        /// Adds an entity
        /// </summary>
        /// <param name="entity">The entity to be added</param>
        /// <returns>Nothing</returns>
        public Task Add(TEntity entity);

        /// <summary>
        /// Removes an entity
        /// </summary>
        /// <param name="entity">The entity to be removed</param>
        public void Delete(TEntity entity);
    }
}

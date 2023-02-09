namespace DGG.Raffle.Infrastructure.Abstract.Repositories
{
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity">Entity to be created</param>
        /// <returns>Void</returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Void</returns>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update entity by id
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// If entity exists asynchronous.
        /// </summary>
        /// <typeparam name="TPrimaryKey">The type of the primary key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>True if the entity exists</returns>
        Task<bool> ExistsAsync<TPrimaryKey>(TPrimaryKey id);

        /// <summary>
        /// Get by id
        /// </summary>
        /// <typeparam name="TPrimaryKey">The type of the primary key.</typeparam>
        /// <param name="id">The id</param>
        /// <returns>
        /// T entity
        /// </returns>
        Task<TEntity> GetByIdAsync<TPrimaryKey>(TPrimaryKey id);
    }
}

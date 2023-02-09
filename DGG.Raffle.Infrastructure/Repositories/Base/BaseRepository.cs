using DGG.Raffle.Infrastructure.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DGG.Raffle.Infrastructure.Repositories.Base
{
    /// <summary>
    /// Base repository for db calls.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="DGG.Raffle.Infrastructure.Abstract.Repositories.IRepository&lt;TEntity&gt;" />
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEfRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepository(DbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        protected DbContext Context { get; private set; }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <typeparam name="TPrimaryKey">The type of the primary key.</typeparam>
        /// <param name="id">The id</param>
        /// <returns>
        /// T entity
        /// </returns>
        public async Task<TEntity> GetByIdAsync<TPrimaryKey>(TPrimaryKey id)
        {
            return await this.Context
                .Set<TEntity>()
                .FindAsync(id)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity">Entity to be created</param>
        public async Task AddAsync(TEntity entity)
        {
            await this.Context
                .AddAsync(entity)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entities">The entities.</param>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.Context
               .AddRangeAsync(entities)
               .ConfigureAwait(false);
        }

        /// <summary>
        /// If entity exists asynchronous.
        /// </summary>
        /// <typeparam name="TPrimaryKey">The type of the primary key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// True if the entity exists
        /// </returns>
        public async Task<bool> ExistsAsync<TPrimaryKey>(TPrimaryKey id)
        {
            var entitiy = await Context
                .Set<TEntity>()
                .FindAsync(id)
                .ConfigureAwait(false);

            return entitiy != default(TEntity);
        }

        /// <summary>
        /// Update entity by id
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public void Update(TEntity entity)
        {
            Context.Update(entity);
        }

        /// <summary>
        /// Updates the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.UpdateRange(entities);
        }
    }
}

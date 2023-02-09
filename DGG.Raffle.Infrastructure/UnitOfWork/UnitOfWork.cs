using DGG.Raffle.Infrastructure.Abstract.UnitOfWork;
using DGG.Raffle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace DGG.Raffle.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Unit of Work: Commits db changes by the services.
    /// </summary>
    /// <seealso cref="DGG.Raffle.Infrastructure.Abstract.UnitOfWork.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfUnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(DggRaffleDbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="EfUnitOfWork"/> class.
        /// </summary>
        ~UnitOfWork()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public DbContext Context { get; }

        /// <inheritdoc />
        public async Task CompleteAsync()
        {
            await this.Context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (disposing)
            {
                Context.Dispose();
            }

            isDisposed = true;
        }
    }
}

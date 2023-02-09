
namespace DGG.Raffle.Infrastructure.Abstract.UnitOfWork
{
    /// <summary>
    /// Interface for the Unit of Work.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits the operations.
        /// </summary>
        Task CompleteAsync();
    }
}

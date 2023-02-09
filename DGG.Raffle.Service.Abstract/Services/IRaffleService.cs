using DGG.Raffle.Business.Abstract.Builders;

namespace DGG.Raffle.Business.Abstract.Services
{
    /// <summary>
    /// Raffle Service Interface.
    /// </summary>
    public interface IRaffleService
    {
        /// <summary>
        /// Creates the raffle session.
        /// </summary>
        /// <returns>The new raffle session Id</returns>
        Task<BusinessResult<Guid>> CreateRaffleSession();
    }
}

using DGG.Raffle.Business.Abstract.Builders;
using DGG.Raffle.Business.Abstract.Models;
using DGG.Raffle.Infrastructure.Abstract.Entities;

namespace DGG.Raffle.Business.Abstract.Services
{
    /// <summary>
    /// Raffle Service Interface.
    /// </summary>
    public interface IRaffleService
    {
        /// <summary>
        /// Creates the raffle entry.
        /// </summary>
        /// <param name="raffleEntryRequest">The raffle entry request.</param>
        /// <returns></returns>
        Task<BusinessResult<RaffleEntries>> CreateRaffleEntry(RaffleEntryBusinessModel raffleEntryRequest);

        /// <summary>
        /// Randomizes the chatters in raffle.
        /// </summary>
        /// <param name="raffleSessionId">The raffle session identifier.</param>
        /// <returns></returns>
        Task<BusinessResult<List<RaffleEntryUserBusinessModel>>> GetRandomizeChattersInRaffle();

        /// <summary>
        /// Gets the raffle winner.
        /// </summary>
        /// <param name="raffleSessionId">The raffle session identifier.</param>
        /// <returns></returns>
        Task<BusinessResult<RaffleEntryUserBusinessModel>> GetRaffleWinner();

        /// <summary>
        /// Gets the money raised.
        /// </summary>
        /// <returns></returns>
        Task<BusinessResult<string>> GetMoneyRaised();

        /// <summary>
        /// Deletes the raffle entry.
        /// </summary>
        /// <param name="raffleEntryId">The raffle entry identifier.</param>
        /// <returns></returns>
        Task<BusinessResult<Guid>> DeleteRaffleEntry(Guid raffleEntryId);
    }
}

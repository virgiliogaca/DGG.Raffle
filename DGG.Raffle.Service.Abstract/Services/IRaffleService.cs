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
        /// Creates the raffle session.
        /// </summary>
        /// <returns>The new raffle session Id</returns>
        Task<BusinessResult<Guid>> CreateRaffleSession();

        /// <summary>
        /// Closes the raffle session.
        /// </summary>
        /// <param name="raffleSessionId">The raffle session identifier.</param>
        /// <returns></returns>
        Task<BusinessResult<Guid>> CloseRaffleSession(Guid raffleSessionId);

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
        Task<BusinessResult<List<RaffleEntryUserBusinessModel>>> GetRandomizeChattersInRaffle(Guid raffleSessionId);

        /// <summary>
        /// Gets the raffle winner.
        /// </summary>
        /// <param name="raffleSessionId">The raffle session identifier.</param>
        /// <returns></returns>
        Task<BusinessResult<RaffleEntryUserBusinessModel>> GetRaffleWinner(Guid raffleSessionId);

        /// <summary>
        /// Gets the money raised.
        /// </summary>
        /// <returns></returns>
        Task<BusinessResult<string>> GetMoneyRaised();
    }
}

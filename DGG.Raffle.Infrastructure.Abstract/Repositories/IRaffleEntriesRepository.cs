using DGG.Raffle.Infrastructure.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGG.Raffle.Infrastructure.Abstract.Repositories
{
    public interface IRaffleEntriesRepository : IRepository<RaffleEntries>
    {
        /// <summary>
        /// Gets the by raffle session identifier.
        /// </summary>
        /// <param name="raffleSessionId">The raffle session identifier.</param>
        /// <returns></returns>
        Task<List<RaffleEntries>> GetByRaffleSessionId(Guid raffleSessionId);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<List<RaffleEntries>> GetAll();
    }
}

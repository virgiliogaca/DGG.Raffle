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
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<List<RaffleEntries>> GetAll();

        /// <summary>
        /// Gets all without winners.
        /// </summary>
        /// <returns></returns>
        Task<List<RaffleEntries>> GetAllWithoutWinners();
    }
}

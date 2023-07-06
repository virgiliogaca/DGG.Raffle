using DGG.Raffle.Infrastructure.Abstract.Entities;
using DGG.Raffle.Infrastructure.Abstract.Repositories;
using DGG.Raffle.Infrastructure.Database;
using DGG.Raffle.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DGG.Raffle.Infrastructure.Repositories
{
    public class RaffleEntriesRepository : BaseRepository<RaffleEntries>, IRaffleEntriesRepository
    {
        public RaffleEntriesRepository(DggRaffleDbContext context)
            : base(context) { }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RaffleEntries>> GetAll()
        {
            return await Context
                .Set<RaffleEntries>()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all without winners.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RaffleEntries>> GetAllWithoutWinners()
        {
            return await Context
                .Set<RaffleEntries>()
                .Where(w => w.isRaffleWinner == false && w.IsActive == true)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}

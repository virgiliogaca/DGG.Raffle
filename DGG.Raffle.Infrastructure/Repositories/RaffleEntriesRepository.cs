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
        /// Gets the by raffle session identifier.
        /// </summary>
        /// <param name="raffleSessionId">The raffle session identifier.</param>
        /// <returns></returns>
        public async Task<List<RaffleEntries>> GetByRaffleSessionId(Guid raffleSessionId)
        {
            return await Context
                .Set<RaffleEntries>()
                .Where(w => w.RaffleSessionId == raffleSessionId && w.IsActive)
                .ToListAsync()
                .ConfigureAwait(false);
        }

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
    }
}

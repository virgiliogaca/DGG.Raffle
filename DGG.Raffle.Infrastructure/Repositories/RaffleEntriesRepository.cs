using DGG.Raffle.Infrastructure.Abstract.Entities;
using DGG.Raffle.Infrastructure.Abstract.Repositories;
using DGG.Raffle.Infrastructure.Database;
using DGG.Raffle.Infrastructure.Repositories.Base;

namespace DGG.Raffle.Infrastructure.Repositories
{
    public class RaffleEntriesRepository : BaseRepository<RaffleEntries>, IRaffleEntriesRepository
    {
        public RaffleEntriesRepository(DggRaffleDbContext context)
            : base(context) { }
    }
}

using DGG.Raffle.Infrastructure.Abstract.Entities;
using DGG.Raffle.Infrastructure.Abstract.Repositories;
using DGG.Raffle.Infrastructure.Database;
using DGG.Raffle.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGG.Raffle.Infrastructure.Repositories
{
    public class RaffleSessionsRepository : BaseRepository<RaffleSessions>, IRaffleSessionsRepository
    {
        public RaffleSessionsRepository(DggRaffleDbContext context)
            : base(context) { }
    }
}

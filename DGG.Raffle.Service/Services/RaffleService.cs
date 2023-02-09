using DGG.Raffle.Infrastructure.Abstract.Repositories;
using DGG.Raffle.Infrastructure.Abstract.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGG.Raffle.Business.Services
{
    /// <summary>
    /// Raffle business service, does operations to return to the controller.
    /// </summary>
    public class RaffleService
    {
        private readonly IRaffleEntriesRepository raffleEntriesRepository;
        private readonly ICharitiesRepository _charitiesRepository;
        private readonly IRaffleSessionsRepository _raffleSessionsRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="RaffleService"/> class.
        /// </summary>
        /// <param name="raffleEntriesRepository">The raffle entries repository.</param>
        /// <param name="charitiesRepository">The charities repository.</param>
        /// <param name="raffleSessionsRepository">The raffle sessions repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public RaffleService(
            IRaffleEntriesRepository raffleEntriesRepository,
            ICharitiesRepository charitiesRepository,
            IRaffleSessionsRepository raffleSessionsRepository,
            IUnitOfWork unitOfWork)
        {
            this.raffleEntriesRepository = raffleEntriesRepository;
            _charitiesRepository = charitiesRepository;
            _raffleSessionsRepository = raffleSessionsRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

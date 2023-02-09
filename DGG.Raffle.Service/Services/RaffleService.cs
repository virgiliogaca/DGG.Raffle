using DGG.Raffle.Business.Abstract.Builders;
using DGG.Raffle.Business.Abstract.Services;
using DGG.Raffle.Infrastructure.Abstract.Entities;
using DGG.Raffle.Infrastructure.Abstract.Repositories;
using DGG.Raffle.Infrastructure.Abstract.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DGG.Raffle.Business.Services
{
    /// <summary>
    /// Raffle business service, does operations to return to the controller.
    /// </summary>
    public class RaffleService : IRaffleService
    {
        private readonly IRaffleEntriesRepository _raffleEntriesRepository;
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
            _raffleEntriesRepository = raffleEntriesRepository;
            _charitiesRepository = charitiesRepository;
            _raffleSessionsRepository = raffleSessionsRepository;
            _unitOfWork = unitOfWork;
        }
         
        public async Task<BusinessResult<Guid>> CreateRaffleSession()
        {
            try
            {
                var newSession = Guid.NewGuid();

                var raffleSession = new RaffleSessions
                {
                    Id = newSession,
                    CreatedBy = "VirgilGC"
                };

                await _raffleSessionsRepository.AddAsync(raffleSession).ConfigureAwait(false);

                await _unitOfWork.CompleteAsync().ConfigureAwait(false);

                return await BusinessResultBuilder<Guid>
                    .Create()
                    .Success()
                    .WithMessage("Session Created successfuly")
                    .WithData(newSession)
                    .WithHttpStatusCode(HttpStatusCode.OK)
                    .BuildAsync().ConfigureAwait(false);
            } 
            catch (Exception ex)
            {
                return await BusinessResultBuilder<Guid>
                    .Create()
                    .Fail()
                    .WithData(Guid.Empty)
                    .WithMessage(ex.Message)
                    .WithHttpStatusCode(HttpStatusCode.BadRequest)
                    .BuildAsync().ConfigureAwait(false);
            }
            
        }
    }
}

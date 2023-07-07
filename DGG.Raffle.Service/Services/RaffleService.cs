using DGG.Raffle.Business.Abstract.Builders;
using DGG.Raffle.Business.Abstract.Models;
using DGG.Raffle.Business.Abstract.Services;
using DGG.Raffle.Business.Enums;
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
        private readonly IUnitOfWork _unitOfWork;
        private static Random rng = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="RaffleService"/> class.
        /// </summary>
        /// <param name="raffleEntriesRepository">The raffle entries repository.</param>
        /// <param name="charitiesRepository">The charities repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public RaffleService(
            IRaffleEntriesRepository raffleEntriesRepository,
            ICharitiesRepository charitiesRepository,
            IUnitOfWork unitOfWork)
        {
            _raffleEntriesRepository = raffleEntriesRepository;
            _charitiesRepository = charitiesRepository;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Deletes the raffle entry.
        /// </summary>
        /// <param name="raffleEntryId">The raffle entry identifier.</param>
        /// <returns></returns>
        public async Task<BusinessResult<Guid>> DeleteRaffleEntry(Guid raffleEntryId)
        {
            try {
                var raffleEntry = await _raffleEntriesRepository.GetByIdAsync(raffleEntryId).ConfigureAwait(false);

                if (raffleEntry == null)
                {
                    return await BusinessResultBuilder<Guid>
                    .Create()
                    .Fail()
                    .WithData(Guid.Empty)
                    .WithMessage("No raffle entries found with that Id")
                    .WithHttpStatusCode(HttpStatusCode.BadRequest)
                    .BuildAsync().ConfigureAwait(false);
                }
                
                raffleEntry.IsActive = false;
                raffleEntry.ModifiedDate = DateTime.UtcNow;
                raffleEntry.ModifiedBy = "VirgilGC";

                _raffleEntriesRepository.Update(raffleEntry);

                await _unitOfWork.CompleteAsync().ConfigureAwait(false);

                return await BusinessResultBuilder<Guid>
                    .Create()
                    .Success()
                    .WithMessage("Raffle entry deleted.")
                    .WithData(raffleEntryId)
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

        public async Task<BusinessResult<RaffleEntries>> CreateRaffleEntry(RaffleEntryBusinessModel raffleEntryRequest)
        {
            try
            {
                if (raffleEntryRequest == null ||
                raffleEntryRequest.ChatterName == string.Empty ||
                raffleEntryRequest.MovieName == string.Empty)
                {
                    return await BusinessResultBuilder<RaffleEntries>
                        .Create()
                        .Fail()
                        .WithData(new RaffleEntries())
                        .WithMessage("Missing values.")
                        .WithHttpStatusCode(HttpStatusCode.BadRequest)
                        .BuildAsync().ConfigureAwait(false);
                }

                if (raffleEntryRequest.MoneyDonated < 1)
                {
                    return await BusinessResultBuilder<RaffleEntries>
                        .Create()
                        .Fail()
                        .WithData(new RaffleEntries())
                        .WithMessage("The minimum amount to donate is $1 USD.")
                        .WithHttpStatusCode(HttpStatusCode.BadRequest)
                        .BuildAsync().ConfigureAwait(false);
                }

                if (raffleEntryRequest.MoneyDonated > 1000)
                {
                    return await BusinessResultBuilder<RaffleEntries>
                        .Create()
                        .Fail()
                        .WithData(new RaffleEntries())
                        .WithMessage("The maximum amount to donate is $1000 USD.")
                        .WithHttpStatusCode(HttpStatusCode.BadRequest)
                        .BuildAsync().ConfigureAwait(false);
                }

                var raffleEntryId = Guid.NewGuid();

                var raffleEntry = new RaffleEntries()
                {
                    Id = raffleEntryId,
                    CharityId = (int)CharityEnum.AgainstMalariaFoundation,
                    ChatterName = raffleEntryRequest.ChatterName,
                    ChatterMovie = raffleEntryRequest.MovieName,
                    MoneyDonated = raffleEntryRequest.MoneyDonated,
                    CreatedBy = "VirgilGC",
                    CreatedDate = DateTime.UtcNow
                };

                await _raffleEntriesRepository.AddAsync(raffleEntry).ConfigureAwait(false);

                await _unitOfWork.CompleteAsync();

                return await BusinessResultBuilder<RaffleEntries>
                        .Create()
                        .Success()
                        .WithMessage("Entry created successfuly")
                        .WithData(raffleEntry)
                        .WithHttpStatusCode(HttpStatusCode.OK)
                        .BuildAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await BusinessResultBuilder<RaffleEntries>
                        .Create()
                        .Fail()
                        .WithMessage(ex.Message)
                        .WithData(new RaffleEntries())
                        .WithHttpStatusCode(HttpStatusCode.BadRequest)
                        .BuildAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Randomizes the chatters in raffle.
        /// </summary>
        /// <param name="raffleSessionId">The raffle session identifier.</param>
        /// <returns></returns>
        public async Task<BusinessResult<List<RaffleEntryUserBusinessModel>>> GetRandomizeChattersInRaffle()
        {
            try
            {
                var raffleEntries = await _raffleEntriesRepository.GetAllWithoutWinners();

                var chatterRaffleTickets = GetRaffleTickets(raffleEntries);

                chatterRaffleTickets = chatterRaffleTickets.OrderBy(a => rng.Next()).ToList();

                return await BusinessResultBuilder<List<RaffleEntryUserBusinessModel>>
                        .Create()
                        .Success()
                        .WithMessage("Randomized Raffle")
                        .WithData(chatterRaffleTickets)
                        .WithHttpStatusCode(HttpStatusCode.OK)
                        .BuildAsync().ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                return await BusinessResultBuilder<List<RaffleEntryUserBusinessModel>>
                        .Create()
                        .Fail()
                        .WithMessage(ex.Message)
                        .WithData(new List<RaffleEntryUserBusinessModel>())
                        .WithHttpStatusCode(HttpStatusCode.BadRequest)
                        .BuildAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets the raffle winner.
        /// </summary>
        /// <returns></returns>
        public async Task<BusinessResult<RaffleEntryUserBusinessModel>> GetRaffleWinner()
        {
            try
            {
                var raffleEntries = await _raffleEntriesRepository.GetAllWithoutWinners();

                var chatterRaffleTickets = GetRaffleTickets(raffleEntries);

                int index = rng.Next(chatterRaffleTickets.Count);
                var getWinner = new RaffleEntryUserBusinessModel()
                {
                    Id = chatterRaffleTickets[index].Id,
                    ChatterMovie = chatterRaffleTickets[index].ChatterMovie,
                    ChatterName = chatterRaffleTickets[index].ChatterName,
                    moneyDonated = chatterRaffleTickets[index].moneyDonated
                };
                var raffleEntry = raffleEntries.Where(x => x.Id == getWinner.Id).FirstOrDefault();

                if (raffleEntry != null)
                {
                    raffleEntry.isRaffleWinner = true;
                    raffleEntry.ModifiedBy = "sys";
                    raffleEntry.ModifiedDate = DateTime.UtcNow;
                    _raffleEntriesRepository.Update(raffleEntry);
                }

                await _unitOfWork.CompleteAsync().ConfigureAwait(false);

                _unitOfWork.Dispose();

                return await BusinessResultBuilder<RaffleEntryUserBusinessModel>
                        .Create()
                        .Success()
                        .WithMessage("Winner winner")
                        .WithData(getWinner)
                        .WithHttpStatusCode(HttpStatusCode.OK)
                        .BuildAsync().ConfigureAwait(false);
            } 
            catch(Exception ex)
            {
                return await BusinessResultBuilder<RaffleEntryUserBusinessModel>
                        .Create()
                        .Fail()
                        .WithMessage(ex.Message)
                        .WithData(new RaffleEntryUserBusinessModel())
                        .WithHttpStatusCode(HttpStatusCode.BadRequest)
                        .BuildAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets the money raised.
        /// </summary>
        /// <returns></returns>
        public async Task<BusinessResult<string>> GetMoneyRaised()
        {
            try
            {
                var raffleEntries = await _raffleEntriesRepository.GetAll().ConfigureAwait(false);
                if (raffleEntries.Count == 0)
                {
                    return await BusinessResultBuilder<string>
                            .Create()
                            .Success()
                            .WithMessage("Got total charity earned.")
                            .WithData("0")
                            .WithHttpStatusCode(HttpStatusCode.OK)
                            .BuildAsync().ConfigureAwait(false);
                }

                var moneyRaised = raffleEntries.Where(x => x.IsActive).Sum(x => x.MoneyDonated).ToString();

                return await BusinessResultBuilder<string>
                            .Create()
                            .Success()
                            .WithMessage("Got total charity earned.")
                            .WithData(moneyRaised)
                            .WithHttpStatusCode(HttpStatusCode.OK)
                            .BuildAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await BusinessResultBuilder<string>
                            .Create()
                            .Success()
                            .WithMessage(ex.Message)
                            .WithData("")
                            .WithHttpStatusCode(HttpStatusCode.BadRequest)
                            .BuildAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets the raffle tickets.
        /// </summary>
        /// <param name="raffleEntries">The raffle entries.</param>
        /// <returns></returns>
        private List<RaffleEntryUserBusinessModel> GetRaffleTickets(List<RaffleEntries> raffleEntries)
        {
            var groupedChatters = raffleEntries
                    .Select(re => new RaffleEntries
                    {
                        Id = re.Id,
                        ChatterName = re.ChatterName,
                        ChatterMovie = re.ChatterMovie,
                        MoneyDonated = re.MoneyDonated
                    })
                    .ToList();

            var chatterRaffleTickets = new List<RaffleEntryUserBusinessModel>();

            foreach (var chatter in groupedChatters)
            {
                for (int i = 0; i < (int)Math.Ceiling(chatter.MoneyDonated); i++)
                {
                    var raffleTicket = new RaffleEntryUserBusinessModel()
                    {
                        ChatterMovie = chatter.ChatterMovie,
                        ChatterName = chatter.ChatterName,
                        Id = chatter.Id,
                        moneyDonated = chatter.MoneyDonated.ToString()
                    };

                    chatterRaffleTickets.Add(raffleTicket);
                }
            }
            return chatterRaffleTickets;
        }
    }
}

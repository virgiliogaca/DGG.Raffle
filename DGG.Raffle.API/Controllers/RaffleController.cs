using DGG.Raffle.API.Controllers.Models.Requests;
using DGG.Raffle.API.Controllers.Models.Responses;
using DGG.Raffle.Business.Abstract.Builders;
using DGG.Raffle.Business.Abstract.Services;
using DGG.Raffle.Business.Abstract.Models;
using DGG.Raffle.Infrastructure.Abstract.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Collections.Generic;

namespace DGG.Raffle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaffleController : ControllerBase
    {
        private readonly IRaffleService _raffleService;

        public RaffleController(IRaffleService raffleService)
        {
            _raffleService= raffleService;
        }

        /// <summary>
        /// Creates a new Raffle entry.
        /// </summary>
        /// <param name="raffleEntryRequest"></param>
        /// <returns></returns>
        [HttpPost("RaffleEntry")]
        [AllowAnonymous]
        public async Task<BusinessResult<RaffleEntryResponse>> CreateRaffleEntry(RaffleEntryRequest raffleEntryRequest)
        {
            var raffleEntry = new RaffleEntryBusinessModel()
            {
                ChatterName = raffleEntryRequest.ChatterName,
                MovieName = raffleEntryRequest.MovieName,
                MoneyDonated = raffleEntryRequest.MoneyDonated,
            };

            var businessResult = await _raffleService.CreateRaffleEntry(raffleEntry);

            var raffleEntryResult = new RaffleEntryResponse()
            {
                Id = businessResult.Data.Id,
                CharityId = businessResult.Data.CharityId,
                ChatterMovie = businessResult.Data.ChatterMovie,
                ChatterName = businessResult.Data.ChatterName,
                MoneyDonated = businessResult.Data.MoneyDonated,
            };

            return await BusinessResultBuilder<RaffleEntryResponse>
            .Create()
                .WithData(raffleEntryResult)
                .WithMessage(businessResult.Message ?? string.Empty)
                .WithHttpStatusCode(businessResult.StatusCode)
                .IsSuccessful(businessResult.isSuccessful)
                .BuildAsync();
        }

        [HttpDelete("RaffleEntry/{raffleEntryId}")]
        [AllowAnonymous]
        public async Task<BusinessResult<Guid>> DeleteRaffleEntry(Guid raffleEntryId)
        {
            var businessResult = await _raffleService.DeleteRaffleEntry(raffleEntryId);

            return await BusinessResultBuilder<Guid>
            .Create()
                .WithData(businessResult.Data)
                .WithMessage(businessResult.Message ?? string.Empty)
                .WithHttpStatusCode(businessResult.StatusCode)
                .IsSuccessful(businessResult.isSuccessful)
                .BuildAsync();
        }

        [HttpGet("RandomizedRaffleEntries")]
        [AllowAnonymous]
        public async Task<BusinessResult<List<RaffleEntryUserBusinessModel>>> GetRandomizedRaffleTickets()
        {
            var businessResult = await _raffleService.GetRandomizeChattersInRaffle();

            return await BusinessResultBuilder<List<RaffleEntryUserBusinessModel>>
            .Create()
                .WithData(businessResult.Data)
                .WithMessage(businessResult.Message ?? string.Empty)
                .WithHttpStatusCode(businessResult.StatusCode)
                .IsSuccessful(businessResult.isSuccessful)
                .BuildAsync();
        }

        [HttpGet("RaffleWinner")]
        [AllowAnonymous]
        public async Task<BusinessResult<RaffleEntryUserBusinessModel>> GetRaffleWinner()
        {
            var businessResult = await _raffleService.GetRaffleWinner();

            return await BusinessResultBuilder<RaffleEntryUserBusinessModel>
            .Create()
                .WithData(businessResult.Data)
                .WithMessage(businessResult.Message ?? string.Empty)
                .WithHttpStatusCode(businessResult.StatusCode)
                .IsSuccessful(businessResult.isSuccessful)
                .BuildAsync();
        }

        [HttpGet("CharityMoneyRaised")]
        [AllowAnonymous]
        public async Task<BusinessResult<string>> GetMoneyRaised()
        {
            var businessResult = await _raffleService.GetMoneyRaised().ConfigureAwait(false);

            return await BusinessResultBuilder<string>
            .Create()
                .WithData(businessResult.Data)
                .WithMessage(businessResult.Message ?? string.Empty)
                .WithHttpStatusCode(businessResult.StatusCode)
                .IsSuccessful(businessResult.isSuccessful)
                .BuildAsync();
        }
    }
}

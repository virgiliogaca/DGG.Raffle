using DGG.Raffle.API.Controllers.Models.Responses;
using DGG.Raffle.Business.Abstract.Builders;
using DGG.Raffle.Business.Abstract.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("RaffleSession")]
        [AllowAnonymous]
        public async Task<BusinessResult<RaffleSessionCreatedResponse>> CreateRaffleSession()
        {
            var businessResult = await _raffleService.CreateRaffleSession();
            var result = new RaffleSessionCreatedResponse { RaffleSessionId = businessResult.Data };
            return await BusinessResultBuilder<RaffleSessionCreatedResponse>
                .Create()
                .WithData(result)
                .WithMessage(businessResult.Message ?? string.Empty)
                .WithHttpStatusCode(businessResult.StatusCode)
                .IsSuccessful(businessResult.isSuccessful)
                .BuildAsync();
        }
    }
}

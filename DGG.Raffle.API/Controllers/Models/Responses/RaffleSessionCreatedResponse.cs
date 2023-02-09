namespace DGG.Raffle.API.Controllers.Models.Responses
{
    /// <summary>
    /// New Raffle Session Created Model.
    /// </summary>
    public class RaffleSessionCreatedResponse
    {
        /// <summary>
        /// Gets or sets the raffle session identifier.
        /// </summary>
        /// <value>
        /// The raffle session identifier.
        /// </value>
        public Guid RaffleSessionId { get; set; }
    }
}

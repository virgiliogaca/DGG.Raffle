namespace DGG.Raffle.API.Controllers.Models.Responses
{
    public class RaffleEntryResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the raffle session identifier.
        /// </summary>
        /// <value>
        /// The raffle session identifier.
        /// </value>
        public Guid RaffleSessionId { get; set; }

        /// <summary>
        /// Gets or sets the charity identifier.
        /// </summary>
        /// <value>
        /// The charity identifier.
        /// </value>
        public int CharityId { get; set; }

        /// <summary>
        /// Gets or sets the name of the chatter.
        /// </summary>
        /// <value>
        /// The name of the chatter.
        /// </value>
        public string ChatterName { get; set; }

        /// <summary>
        /// Gets or sets the chatter movie.
        /// </summary>
        /// <value>
        /// The chatter movie.
        /// </value>
        public string ChatterMovie { get; set; }

        /// <summary>
        /// Gets or sets the money donated.
        /// </summary>
        /// <value>
        /// The money donated.
        /// </value>
        public double MoneyDonated { get; set; }
    }
}

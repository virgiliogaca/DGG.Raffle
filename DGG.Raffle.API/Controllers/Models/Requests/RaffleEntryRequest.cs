namespace DGG.Raffle.API.Controllers.Models.Requests
{
    /// <summary>
    /// Raffle entry model for requests.
    /// </summary>
    public class RaffleEntryRequest
    {
        /// <summary>
        /// Gets or sets the name of the chatter.
        /// </summary>
        /// <value>
        /// The name of the chatter.
        /// </value>
        public string ChatterName { get; set; }

        /// <summary>
        /// Gets or sets the name of the movie.
        /// </summary>
        /// <value>
        /// The name of the movie.
        /// </value>
        public string MovieName { get; set;}

        /// <summary>
        /// Gets or sets the money donated.
        /// </summary>
        /// <value>
        /// The money donated.
        /// </value>
        public double MoneyDonated { get; set;}
    }
}

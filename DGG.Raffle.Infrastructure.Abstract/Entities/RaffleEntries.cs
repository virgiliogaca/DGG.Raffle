using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DGG.Raffle.Infrastructure.Abstract.Entities
{
    [Table("RaffleEntries", Schema = "dbo")]
    public class RaffleEntries: AuditEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RaffleEntries"/> class.
        /// </summary>
        public RaffleEntries() { 
            isRaffleWinner = false;
            ChatterMovie = string.Empty;
            ChatterName = string.Empty;
            RaffleSession = new RaffleSessions();
            Charity = new Charities();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the raffle session identifier.
        /// </summary>
        /// <value>
        /// The raffle session identifier.
        /// </value>
        [ForeignKey(nameof(RaffleSessions.Id))]
        [Required]
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
        [Required]
        public string ChatterName { get; set; }

        /// <summary>
        /// Gets or sets the chatter movie.
        /// </summary>
        /// <value>
        /// The chatter movie.
        /// </value>
        [Required]
        public string ChatterMovie { get; set; }

        /// <summary>
        /// Gets or sets the money donated.
        /// </summary>
        /// <value>
        /// The money donated.
        /// </value>
        [Required]
        public double MoneyDonated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is raffle winner.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is raffle winner; otherwise, <c>false</c>.
        /// </value>
        public bool isRaffleWinner { get; set; }

        /// <summary>
        /// Gets or sets the raffle session.
        /// </summary>
        /// <value>
        /// The raffle session.
        /// </value>
        public RaffleSessions RaffleSession { get; set; }

        /// <summary>
        /// Gets or sets the charity.
        /// </summary>
        /// <value>
        /// The charity.
        /// </value>
        public Charities Charity { get; set; }
    }
}

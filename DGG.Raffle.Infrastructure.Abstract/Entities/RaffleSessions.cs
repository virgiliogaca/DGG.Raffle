using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DGG.Raffle.Infrastructure.Abstract.Entities
{
    [Table("RaffleSessions", Schema = "dbo")]
    public class RaffleSessions : AuditEntity
    {
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
        /// Gets or sets the raffle entry.
        /// </summary>
        /// <value>
        /// The raffle entry.
        /// </value>
        public List<RaffleEntries>? RaffleEntry { get; set; }
    }
}

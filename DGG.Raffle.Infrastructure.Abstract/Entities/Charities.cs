using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DGG.Raffle.Infrastructure.Abstract.Entities
{
    [Table("Charities", Schema = "catalog")]
    public class Charities: AuditEntity
    {
        public Charities() {
            Name = string.Empty;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the raffle entry.
        /// </summary>
        /// <value>
        /// The raffle entry.
        /// </value>
        public List<RaffleEntries>? RaffleEntry { get; set; }
    }
}

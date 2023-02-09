using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGG.Raffle.Business.Abstract.Models
{
    public class RaffleEntryBusinessModel
    {
        /// <summary>
        /// Gets or sets the raffle session identifier.
        /// </summary>
        /// <value>
        /// The raffle session identifier.
        /// </value>
        public Guid RaffleSessionId { get; set; }

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
        public string MovieName { get; set; }

        /// <summary>
        /// Gets or sets the money donated.
        /// </summary>
        /// <value>
        /// The money donated.
        /// </value>
        public double MoneyDonated { get; set; }
    }
}

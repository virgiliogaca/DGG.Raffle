using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGG.Raffle.Business.Abstract.Models
{
    public class RaffleEntryUserBusinessModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
    }
}

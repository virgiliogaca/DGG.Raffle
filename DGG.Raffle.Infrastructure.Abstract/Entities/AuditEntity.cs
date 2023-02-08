namespace DGG.Raffle.Infrastructure.Abstract.Entities
{
    public class AuditEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditEntity"/> class.
        /// </summary>
        public AuditEntity()
        {
            CreatedDate = DateTime.UtcNow;
            IsActive = true;
        }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [modified date].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [modified date]; otherwise, <c>false</c>.
        /// </value>
        public bool ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        public string? ModifiedBy { get; set;}

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}

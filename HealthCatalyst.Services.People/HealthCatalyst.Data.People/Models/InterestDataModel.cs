using System;

namespace HealthCatalyst.Data.People.Models
{
    /// <summary>
    /// Interest Data Model
    /// </summary>
    public class InterestDataModel
    {
        /// <summary>
        /// Creation Date
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Contact Method ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Person ID
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Date Last Updated
        /// </summary>
        public DateTimeOffset Updated { get; set; }
    }
}

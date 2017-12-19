using System;

namespace HealthCatalyst.Data.People.Models
{
    /// <summary>
    /// Contact Method Data Model
    /// </summary>
    public class ContactMethodDataModel
    {
        /// <summary>
        /// Contact Method Type ID
        /// </summary>
        public int ContactMethodTypeId { get; set; }

        /// <summary>
        /// Creation Date
        /// </summary>
        public DateTimeOffset Created { get; set; }

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

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}

using System;

namespace HealthCatalyst.Data.People.Models
{
    /// <summary>
    /// Address Data Model
    /// </summary>
    public class AddressDataModel
    {
        /// <summary>
        /// Address 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Creation Date
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Address Model ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Person ID
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Postal Code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// Date Last Updated
        /// </summary>
        public DateTimeOffset Updated { get; set; }
    }
}

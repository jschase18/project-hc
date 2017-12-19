using System;

namespace HealthCatalyst.Data.People.Models
{
    /// <summary>
    /// Person Data Model
    /// </summary>
    public class PersonDataModel
    {
        /// <summary>
        /// Age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Creation Date
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Person ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Profile Picture URL
        /// </summary>
        public string ProfilePictureUrl { get; set; }

        /// <summary>
        /// Date Last Updated
        /// </summary>
        public DateTimeOffset Updated { get; set; }
    }
}

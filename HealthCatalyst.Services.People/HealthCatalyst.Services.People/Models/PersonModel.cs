namespace HealthCatalyst.Services.People.Models
{
    /// <summary>
    /// Person Model
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Age
        /// </summary>
        public int Age { get; set; }

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
    }
}

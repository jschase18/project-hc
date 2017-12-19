using System.Collections.Generic;

namespace HealthCatalyst.Services.People.Models
{
    /// <summary>
    /// Person Detail Model
    /// </summary>
    public class PersonDetailModel : PersonModel
    {
        /// <summary>
        /// Addresses
        /// </summary>
        public List<AddressModel> Addresses { get; set; }

        /// <summary>
        /// Contact Methods
        /// </summary>
        public List<ContactMethodModel> ContactMethods { get; set; }

        /// <summary>
        /// Interests
        /// </summary>
        public List<InterestModel> Interests { get; set; }
    }
}

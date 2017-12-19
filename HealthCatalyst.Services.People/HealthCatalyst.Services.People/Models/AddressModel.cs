namespace HealthCatalyst.Services.People.Models
{
    /// <summary>
    /// Address Model
    /// </summary>
    public class AddressModel
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
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Address Model ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// Postal Code
        /// </summary>
        public string PostalCode { get; set; }
    }
}

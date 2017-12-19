namespace HealthCatalyst.Services.People.Models
{
    /// <summary>
    /// Contact Method Model
    /// </summary>
    public class ContactMethodModel
    {
        /// <summary>
        /// Contact Method ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public int ContactMethodTypeId { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}

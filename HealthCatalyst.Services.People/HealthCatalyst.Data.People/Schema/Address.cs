using System;

namespace HealthCatalyst.Data.People.Schema
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int PersonId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string PostalCode { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual State State { get; set; }
        public virtual Person Person { get; set; }
    }
}

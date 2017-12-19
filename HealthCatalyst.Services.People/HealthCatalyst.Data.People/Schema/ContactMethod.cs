using System;

namespace HealthCatalyst.Data.People.Schema
{
    public partial class ContactMethod
    {
        public int ContactMethodId { get; set; }
        public int PersonId { get; set; }
        public string Value { get; set; }
        public int ContactMethodTypeId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ContactMethodType ContactMethodType { get; set; }
        public virtual Person Person { get; set; }
    }
}

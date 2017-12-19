using System;

namespace HealthCatalyst.Data.People.Schema
{
    public partial class Interest
    {
        public int InterestId { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual Person Person { get; set; }
    }
}

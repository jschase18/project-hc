using System.Collections.Generic;

namespace HealthCatalyst.Data.People.Schema
{
    public partial class State
    {
        public State()
        {
            Addresses = new List<Address>();
        }

        public int StateId { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}

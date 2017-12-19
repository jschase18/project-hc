using System.Collections.Generic;

namespace HealthCatalyst.Data.People.Schema
{
    public partial class ContactMethodType
    {
        public ContactMethodType()
        {
            ContactMethods = new List<ContactMethod>();
        }

        public int ContactMethodTypeId { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<ContactMethod> ContactMethods { get; set; }
    }
}

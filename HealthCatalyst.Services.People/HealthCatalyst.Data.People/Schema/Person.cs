using System;
using System.Collections.Generic;

namespace HealthCatalyst.Data.People.Schema
{
    public partial class Person
    {
        public Person()
        {
            Addresses = new List<Address>();
            ContactMethods = new List<ContactMethod>();
            Interests = new List<Interest>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<ContactMethod> ContactMethods { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
    }
}

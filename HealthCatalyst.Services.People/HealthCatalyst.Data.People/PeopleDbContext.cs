using System.Data.Entity;
using HealthCatalyst.Data.People.Schema;
using HealthCatalyst.Data.People.Schema.Mapping;

namespace HealthCatalyst.Data.People
{
    /// <summary>
    /// People Database Context
    /// </summary>
    public partial class PeopleDbContext : DbContext
    {
        public PeopleDbContext(string connectionString, bool dropAndRecreateDatabase)
            : base(connectionString)
        {
            if(dropAndRecreateDatabase)
            {
                Database.SetInitializer(new PeopleCleanDbInitializer());
            }
            else
            {
                Database.SetInitializer(new PeopleDbInitializer());
            }
        }

        public DbSet<ContactMethodType> ContactMethodTypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactMethod> ContactMethods { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactMethodTypeMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new ContactMethodMap());
            modelBuilder.Configurations.Add(new InterestMap());
            modelBuilder.Configurations.Add(new PersonMap());
        }
    }
}

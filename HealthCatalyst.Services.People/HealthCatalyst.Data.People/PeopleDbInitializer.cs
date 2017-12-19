using System.Data.Entity;
using HealthCatalyst.Data.People.Helpers;

namespace HealthCatalyst.Data.People
{
    /// <summary>
    /// Default Database Initializer - creates the database if it does not exist
    /// </summary>
    public class PeopleDbInitializer : CreateDatabaseIfNotExists<PeopleDbContext>
    {
        protected override void Seed(PeopleDbContext context)
        {
            SeedDataManager.ApplySeedDataToDbContext(context);
            base.Seed(context);
        }
    }
}

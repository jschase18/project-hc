using System.Data.Entity;
using HealthCatalyst.Data.People.Helpers;

namespace HealthCatalyst.Data.People
{
    /// <summary>
    /// Database Initializer that always drops and recreates the database
    /// </summary>
    public class PeopleCleanDbInitializer : DropCreateDatabaseAlways<PeopleDbContext>
    {
        protected override void Seed(PeopleDbContext context)
        {
            SeedDataManager.ApplySeedDataToDbContext(context);
            base.Seed(context);
        }
    }
}

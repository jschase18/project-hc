using System.Collections.Generic;
using System.Linq;
using HealthCatalyst.Data.People.Interfaces;
using HealthCatalyst.Data.People.Models;

namespace HealthCatalyst.Data.People.Agents
{
    public class CatalogDataAgent : ICatalogDataAgent
    {
        private readonly string _connectingString;
        private readonly bool _dropAndRecreateDatabase;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        public CatalogDataAgent(string connectionString)
            : this(connectionString, false)
        {

        }

        /// <summary>
        /// Default Constructor for unit/integration tests
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="dropAndRecreateDatabase">True if the database should be dropped and created</param>
        internal CatalogDataAgent(string connectionString, bool dropAndRecreateDatabase)
        {
            _connectingString = connectionString;
            _dropAndRecreateDatabase = dropAndRecreateDatabase;
        }

        /// <summary>
        /// Selects all contact method type record details
        /// </summary>
        public List<CatalogDataModel> SelectContactMethodTypes()
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                return context.ContactMethodTypes.Select(x => new CatalogDataModel
                {
                    Id = x.ContactMethodTypeId,
                    Name = x.Name
                }).ToList();
            }
        }

        /// <summary>
        /// Selects all state record details
        /// </summary>
        public List<CatalogDataModel> SelectStates()
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                return context.States.Select(x => new CatalogDataModel
                {
                    Id = x.StateId,
                    Name = x.Name
                }).ToList();
            }
        }
    }
}

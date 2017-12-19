using System.Collections.Generic;
using System.Linq;
using HealthCatalyst.Data.People.Interfaces;
using HealthCatalyst.Services.People.Interfaces;
using HealthCatalyst.Services.People.Models;

namespace HealthCatalyst.Services.People.Agents
{
    /// <summary>
    /// Catalog Agent
    /// </summary>
    public class CatalogAgent : ICatalogAgent
    {
        private readonly ICatalogDataAgent _catalogDataAgent;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CatalogAgent(ICatalogDataAgent catalogDataAgent)
        {
            _catalogDataAgent = catalogDataAgent;
        }

        /// <summary>
        /// Gets a list of contact method types
        /// </summary>
        public List<CatalogItemModel> GetContactMethodTypes()
        {
            return _catalogDataAgent.SelectContactMethodTypes().Select(x => new CatalogItemModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        /// <summary>
        /// Gets a list of states (for addresses)
        /// </summary>
        public List<CatalogItemModel> GetStates()
        {
            return _catalogDataAgent.SelectStates().Select(x => new CatalogItemModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}

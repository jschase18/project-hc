using System.Collections.Generic;
using System.Web.Http;
using HealthCatalyst.Data.People.Agents;
using HealthCatalyst.Services.People.Agents;
using HealthCatalyst.Services.People.Interfaces;
using HealthCatalyst.Services.People.Models;

namespace HealthCatalyst.Services.People.Controllers
{
    /// <summary>
    /// Catalog Controller
    /// </summary>
    [RoutePrefix("catalog")]
    public class CatalogController : ApiController
    {
        private readonly ICatalogAgent _catalogAgent;

        /// <summary>
        /// Default Controller
        /// </summary>
        public CatalogController()
        {
            var dataAgent = new CatalogDataAgent(Settings.Instance.ConnectionString);
            _catalogAgent = new CatalogAgent(dataAgent);
        }

        /// <summary>
        /// Default Controller for Unit Testing
        /// </summary>
        public CatalogController(ICatalogAgent catalogAgent)
        {
            _catalogAgent = catalogAgent;
        }

        /// <summary>
        /// Gets a list of available contact methods recognized by the system
        /// </summary>
        /// <returns>Contact Method Types</returns>
        [HttpGet]
        [Route("contact-method-types")]
        public List<CatalogItemModel> GetContactMethodTypes()
        {
            return _catalogAgent.GetContactMethodTypes();
        }

        /// <summary>
        /// Gets a list of states that can be assigned to addresses
        /// </summary>
        /// <returns>States</returns>
        [HttpGet]
        [Route("states")]
        public List<CatalogItemModel> GetStates()
        {
            return _catalogAgent.GetStates();
        }
    }
}

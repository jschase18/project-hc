using HealthCatalyst.Services.People.Models;
using System.Collections.Generic;

namespace HealthCatalyst.Services.People.Interfaces
{
    /// <summary>
    /// Interface for defining Catalog Agent Logic
    /// </summary>
    public interface ICatalogAgent
    {
        /// <summary>
        /// Gets a list of contact method types
        /// </summary>
        List<CatalogItemModel> GetContactMethodTypes();

        /// <summary>
        /// Gets a list of states (for addresses)
        /// </summary>
        List<CatalogItemModel> GetStates();
    }
}

using System.Collections.Generic;
using HealthCatalyst.Data.People.Models;

namespace HealthCatalyst.Data.People.Interfaces
{
    /// <summary>
    /// Interface for defining Catalog Data Agent Logic
    /// </summary>
    public interface ICatalogDataAgent
    {
        /// <summary>
        /// Selects all contact method type record details
        /// </summary>
        List<CatalogDataModel> SelectContactMethodTypes();

        /// <summary>
        /// Selects all state record details
        /// </summary>
        List<CatalogDataModel> SelectStates();   
    }
}

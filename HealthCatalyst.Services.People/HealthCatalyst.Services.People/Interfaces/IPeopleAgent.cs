using System.Collections.Generic;
using HealthCatalyst.Services.People.Models;

namespace HealthCatalyst.Services.People.Interfaces
{
    /// <summary>
    /// Interface for defining People Agent Logic
    /// </summary>
    public interface IPeopleAgent
    {
        /// <summary>
        /// Gets detailed information for the person with the given 
        /// ID if they exist in the system. Otherwise returns null.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person </returns>
        PersonDetailModel GetPersonDetail(int personId);

        /// <summary>
        /// Saves an address record to be associated with the person 
        /// with the given ID.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="address">Address information to save</param>
        /// <returns>Address information that was saved</returns>
        AddressModel SaveAddress(int personId, AddressModel address);

        /// <summary>
        /// Saves a person to the system. Updates the person if 
        /// they already exist, inserts the person otherwise.
        /// </summary>
        /// <param name="person">Person information to save</param>
        /// <returns>Person information that was saved</returns>
        PersonModel SavePerson(PersonModel person);

        /// <summary>
        /// Saves a contact method record to be associated with the person 
        /// with the given ID.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="address">Contact method information to save</param>
        /// <returns>Contact method information that was saved</returns>
        ContactMethodModel SaveContactMethod(int personId, ContactMethodModel contactMethod);

        /// <summary>
        /// Saves an interest record to be associated with the person 
        /// with the given ID.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="address">Interest information to save</param>
        /// <returns>Interest information that was saved</returns>
        InterestModel SaveInterest(int personId, InterestModel interest);

        /// <summary>
        /// Searches the system for all people where any part of 
        /// their first or last name matches the given search term.
        /// </summary>
        /// <param name="searchTerm">Search term (for first or last name)</param>
        /// <returns>All people whose first or last name contains the search term</returns>
        List<PersonModel> SearchPeople(string searchTerm);
    }
}

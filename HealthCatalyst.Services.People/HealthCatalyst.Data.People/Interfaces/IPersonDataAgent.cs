using System.Collections.Generic;
using HealthCatalyst.Data.People.Models;

namespace HealthCatalyst.Data.People.Interfaces
{
    /// <summary>
    /// Interface for defining Person Data Agent Logic
    /// </summary>
    public interface IPersonDataAgent
    {
        /// <summary>
        /// Inserts of updates a person record.
        /// </summary>
        /// <param name="personData">Person information to insert or update</param>
        /// <returns>Person information that was inserted or updated</returns>
        PersonDataModel InsertOrUpdatePerson(PersonDataModel personData);

        /// <summary>
        /// Inserts or updates an address record for a person record.
        /// </summary>
        /// <param name="addressData">Address information to insert or update</param>
        /// <returns>Address information that was inserted or updated</returns>
        AddressDataModel InsertOrUpdateAddress(AddressDataModel addressData);

        /// <summary>
        /// Inserts or updates a contact information record for a person record.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="contactMethodData">Contact method information to save</param>
        /// <returns>Contact method information that was saved</returns>
        ContactMethodDataModel InsertOrUpdateContactMethod(ContactMethodDataModel contactMethodData);

        /// <summary>
        /// Inserts or updates a contact information record for a person record.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="interestData">Interest information to save</param>
        /// <returns>Interest information that was saved</returns>
        InterestDataModel InsertOrUpdateInterest(InterestDataModel interestData);

        /// <summary>
        /// Searches the system for all persn records where any part of 
        /// first or last name column values matches the given search term.
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        /// <returns>All person records whose first or last column value contains the search term</returns>
        List<PersonDataModel> SearchPeople(string searchTerm);

        /// <summary>
        /// Selects the person record associated with the given 
        /// ID if they exist in the system. Otherwise returns null.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person Data</returns>
        PersonDataModel SelectPersonData(int personId);

        /// <summary>
        /// Selects the address records associated with the given 
        /// person ID if they exist in the system. Otherwise returns empty.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person Address Data</returns>
        List<AddressDataModel> SelectAddressData(int personId);

        /// <summary>
        /// Selects the contact method records associated with the given 
        /// person ID if they exist in the system. Otherwise returns empty.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person Contact Method Data</returns>
        List<ContactMethodDataModel> SelectContactMethodData(int personId);

        /// <summary>
        /// Selects the interest records associated with the given 
        /// person ID if they exist in the system. Otherwise returns empty.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person Contact Method Data</returns>
        List<InterestDataModel> SelectInterestData(int personId);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HealthCatalyst.Data.People.Interfaces;
using HealthCatalyst.Services.People.Helpers;
using HealthCatalyst.Services.People.Interfaces;
using HealthCatalyst.Services.People.Models;

namespace HealthCatalyst.Services.People.Agents
{
    /// <summary>
    /// People Agent
    /// </summary>
    public class PeopleAgent : IPeopleAgent
    {
        private readonly IPersonDataAgent _personDataAgent;
        private readonly bool _simulateLatencyOnSearch;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PeopleAgent(IPersonDataAgent personDataAgent, bool simulateLatencyOnSearch)
        {
            _personDataAgent = personDataAgent;
            _simulateLatencyOnSearch = simulateLatencyOnSearch;
        }

        /// <summary>
        /// Gets detailed information for the person with the given 
        /// ID if they exist in the system. Otherwise returns null.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person </returns>
        public PersonDetailModel GetPersonDetail(int personId)
        {
            var personData = _personDataAgent.SelectPersonData(personId);
            if(personData == null)
            {
                return null;
            }

            var addressData = _personDataAgent.SelectAddressData(personId);
            var contactMethodData = _personDataAgent.SelectContactMethodData(personId);
            var interestData = _personDataAgent.SelectInterestData(personId);

            return ModelMapper.MapToPersonDetailModel(personData, addressData, contactMethodData, interestData);
        }

        /// <summary>
        /// Saves an address record to be associated with the person 
        /// with the given ID.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="address">Address information to save</param>
        /// <returns>Address information that was saved</returns>
        public AddressModel SaveAddress(int personId, AddressModel address)
        {
            var addressData = _personDataAgent.InsertOrUpdateAddress(DataModelMapper.MapToAddressDataModel(personId, address));
            return ModelMapper.MapToAddressModel(addressData);
        }

        /// <summary>
        /// Saves a contact method record to be associated with the person 
        /// with the given ID.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="address">Contact method information to save</param>
        /// <returns>Contact method information that was saved</returns>
        public ContactMethodModel SaveContactMethod(int personId, ContactMethodModel contactMethod)
        {
            var contactMethodData = _personDataAgent.InsertOrUpdateContactMethod(DataModelMapper.MapToContactMethodDataModel(personId, contactMethod));
            return ModelMapper.MapToContactMethodModel(contactMethodData);
        }

        /// <summary>
        /// Saves an interest record to be associated with the person 
        /// with the given ID.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="address">Interest information to save</param>
        /// <returns>Interest information that was saved</returns>
        public InterestModel SaveInterest(int personId, InterestModel interest)
        {
            var interestData = _personDataAgent.InsertOrUpdateInterest(DataModelMapper.MapToInterestDataModel(personId, interest));
            return ModelMapper.MapToInterestModel(interestData);

        }

        /// <summary>
        /// Saves a person to the system. Updates the person if 
        /// they already exist, inserts the person otherwise.
        /// </summary>
        /// <param name="person">Person information to save</param>
        /// <returns>Person information that was saved</returns>
        public PersonModel SavePerson(PersonModel person)
        {
            var personData = _personDataAgent.InsertOrUpdatePerson(DataModelMapper.MapToPersonDataModel(person));
            return ModelMapper.MapToPersonModel(personData);
        }

        /// <summary>
        /// Searches the system for all people where any part of 
        /// their first or last name matches the given search term.
        /// </summary>
        /// <param name="searchTerm">Search term (for first or last name)</param>
        /// <returns>All people whose first or last name contains the search term</returns>
        public List<PersonModel> SearchPeople(string searchTerm)
        {
            if(_simulateLatencyOnSearch)
            {
                Thread.Sleep(5000);
            }

            var peopleData = _personDataAgent.SearchPeople(searchTerm);
            return peopleData.Select(x => ModelMapper.MapToPersonModel(x)).ToList();
        }
    }
}

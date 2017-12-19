using System.Collections.Generic;
using System.Web.Http;
using HealthCatalyst.Data.People.Agents;
using HealthCatalyst.Services.People.Agents;
using HealthCatalyst.Services.People.Interfaces;
using HealthCatalyst.Services.People.Models;

namespace HealthCatalyst.Services.People.Controllers
{
    /// <summary>
    /// People API Controller
    /// </summary>
    [RoutePrefix("people")]
    public class PeopleController : ApiController
    {
        private readonly IPeopleAgent _peopleAgent;

        /// <summary>
        /// Default Controller
        /// </summary>
        public PeopleController()
        {
            var dataAgent = new PersonDataAgent(Settings.Instance.ConnectionString);
            _peopleAgent = new PeopleAgent(dataAgent, Settings.Instance.EnableLatencySimulation);
        }

        /// <summary>
        /// Default Controller for Unit Testing
        /// </summary>
        public PeopleController(IPeopleAgent peopleAgent)
        {
            _peopleAgent = peopleAgent;
        }

        /// <summary>
        /// Gets detailed information for the person with the given 
        /// ID if they exist in the system. Otherwise returns null.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person Details</returns>
        [HttpGet]
        [Route("{personId:int}")]
        public PersonDetailModel GetPersonDetail(int personId)
        {
            return _peopleAgent.GetPersonDetail(personId);
        }

        /// <summary>
        /// Saves a person to the system. Updates the person if 
        /// they already exist, inserts the person otherwise.
        /// </summary>
        /// <param name="person">Person information to save</param>
        /// <returns>Person information that was saved</returns>
        [HttpPost]
        [Route("")]
        public PersonModel SavePerson(PersonModel person)
        {
            return _peopleAgent.SavePerson(person);
        }

        /// <summary>
        /// Saves an address record to be associated with the person 
        /// with the given ID.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="address">Address information to save</param>
        /// <returns>Address information that was saved</returns>
        [HttpPost]
        [Route("{personId:int}/address")]
        public AddressModel SaveAddress(int personId, AddressModel address)
        {
            return _peopleAgent.SaveAddress(personId, address);
        }

        /// <summary>
        /// Saves a contact method record to be associated with the person 
        /// with the given ID.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="address">Contact method information to save</param>
        /// <returns>Contact method information that was saved</returns>
        [HttpPost]
        [Route("{personId:int}/contact-method")]
        public ContactMethodModel SaveContactMethod(int personId, ContactMethodModel contactMethod)
        {
            return _peopleAgent.SaveContactMethod(personId, contactMethod);
        }

        /// <summary>
        /// Saves a contact method record to be associated with the person 
        /// with the given ID.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="interest">Interest information to save</param>
        /// <returns>Interest information that was saved</returns>
        [HttpPost]
        [Route("{personId:int}/interest")]
        public InterestModel SaveInterest(int personId, InterestModel interest)
        {
            return _peopleAgent.SaveInterest(personId, interest);
        }

        /// <summary>
        /// Searches the system for all people where any part of 
        /// their first or last name matches the given search term.
        /// </summary>
        /// <param name="searchTerm">Search term (for first or last name)</param>
        /// <returns>All people whose first or last name contains the search term</returns>
        [HttpGet]
        [Route("search/{searchTerm}")]
        public List<PersonModel> SearchPeople(string searchTerm)
        {
            return _peopleAgent.SearchPeople(searchTerm);
        }
    }
}

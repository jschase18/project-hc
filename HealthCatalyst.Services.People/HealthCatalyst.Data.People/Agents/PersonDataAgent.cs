using System.Collections.Generic;
using System.Linq;
using HealthCatalyst.Data.People.Helpers;
using HealthCatalyst.Data.People.Interfaces;
using HealthCatalyst.Data.People.Models;

namespace HealthCatalyst.Data.People.Agents
{
    /// <summary>
    /// Person Data Agent
    /// </summary>
    public class PersonDataAgent : IPersonDataAgent
    {
        private readonly string _connectingString;
        private readonly bool _dropAndRecreateDatabase;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        public PersonDataAgent(string connectionString)
            : this(connectionString, false)
        {
            
        }

        /// <summary>
        /// Default Constructor for unit/integration tests
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="dropAndRecreateDatabase">True if the database should be dropped and created</param>
        internal PersonDataAgent(string connectionString, bool dropAndRecreateDatabase)
        {
            _connectingString = connectionString;
            _dropAndRecreateDatabase = dropAndRecreateDatabase;
        }

        /// <summary>
        /// Inserts of updates a person record.
        /// </summary>
        /// <param name="personData">Person information to insert or update</param>
        /// <returns>Person information that was inserted or updated</returns>
        public PersonDataModel InsertOrUpdatePerson(PersonDataModel personData)
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                var dbPerson = context.People.FirstOrDefault(x => x.PersonId == personData.Id);
                var addNewRecord = dbPerson == null;

                dbPerson = SchemaMapper.MapToSchemaPerson(dbPerson, personData);
                if(addNewRecord)
                {
                    context.People.Add(dbPerson);
                }
                
                context.SaveChanges();

                return DataModelMapper.MapToPersonDataModel(dbPerson);
            }
        }

        /// <summary>
        /// Inserts or updates an address record for a person record.
        /// </summary>
        /// <param name="addressData">Address information to insert or update</param>
        /// <returns>Address information that was inserted or updated</returns>
        public AddressDataModel InsertOrUpdateAddress(AddressDataModel addressData)
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                var dbAddress = context.Addresses.FirstOrDefault(x => x.AddressId == addressData.Id);
                var addNewRecord = dbAddress == null;

                dbAddress = SchemaMapper.MapToSchemaAddress(dbAddress, addressData);
                if (addNewRecord)
                {
                    context.Addresses.Add(dbAddress);
                }

                context.SaveChanges();

                return DataModelMapper.MapToAddressDataModel(dbAddress);
            }
        }

        /// <summary>
        /// Inserts or updates a contact information record for a person record.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="address">Contact method information to save</param>
        /// <returns>Contact method information that was saved</returns>
        public ContactMethodDataModel InsertOrUpdateContactMethod(ContactMethodDataModel contactMethodData)
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                var dbContactMethod = context.ContactMethods.FirstOrDefault(x => x.ContactMethodId == contactMethodData.Id);
                var addNewRecord = dbContactMethod == null;

                dbContactMethod = SchemaMapper.MapToSchemaContactMethod(dbContactMethod, contactMethodData);
                if (addNewRecord)
                {
                    context.ContactMethods.Add(dbContactMethod);
                }

                context.SaveChanges();

                return DataModelMapper.MapToContactMethodDataModel(dbContactMethod);
            }
        }

        /// <summary>
        /// Inserts or updates a contact information record for a person record.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <param name="interestData">Interest information to save</param>
        /// <returns>Interest information that was saved</returns>
        public InterestDataModel InsertOrUpdateInterest(InterestDataModel interestData)
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                var dbInterest = context.Interests.FirstOrDefault(x => x.InterestId == interestData.Id);
                var addNewRecord = dbInterest == null;

                dbInterest = SchemaMapper.MapToSchemaInterest(dbInterest, interestData);
                if (addNewRecord)
                {
                    context.Interests.Add(dbInterest);
                }

                context.SaveChanges();

                return DataModelMapper.MapToInterestDataModel(dbInterest);
            }
        }

        /// <summary>
        /// Searches the system for all persn records where any part of 
        /// first or last name column values matches the given search term.
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        /// <returns>All person records whose first or last column value contains the search term</returns>
        public List<PersonDataModel> SearchPeople(string searchTerm)
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                var dbPeople = context.People.Where(x => x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm)).ToList();
                return dbPeople.Select(DataModelMapper.MapToPersonDataModel).ToList();
            }
        }

        /// <summary>
        /// Selects the address records associated with the given 
        /// person ID if they exist in the system. Otherwise returns empty.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person Address Data</returns>
        public List<AddressDataModel> SelectAddressData(int personId)
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                var dbAddresses = context.Addresses.Where(x => x.PersonId == personId).ToList();
                return dbAddresses.Select(DataModelMapper.MapToAddressDataModel).ToList();
            }
        }

        /// <summary>
        /// Selects the contact method records associated with the given 
        /// person ID if they exist in the system. Otherwise returns empty.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person Contact Method Data</returns>
        public List<ContactMethodDataModel> SelectContactMethodData(int personId)
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                var dbContactMethods = context.ContactMethods.Where(x => x.PersonId == personId).ToList();
                return dbContactMethods.Select(DataModelMapper.MapToContactMethodDataModel).ToList();
            }
        }

        /// <summary>
        /// Selects the interest records associated with the given 
        /// person ID if they exist in the system. Otherwise returns empty.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person Contact Method Data</returns>
        public List<InterestDataModel> SelectInterestData(int personId)
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                var dbInterests = context.Interests.Where(x => x.PersonId == personId).ToList();
                return dbInterests.Select(DataModelMapper.MapToInterestDataModel).ToList();
            }
        }

        /// <summary>
        /// Selects the person record associated with the given 
        /// ID if they exist in the system. Otherwise returns null.
        /// </summary>
        /// <param name="personId">Person ID</param>
        /// <returns>Person Data</returns>
        public PersonDataModel SelectPersonData(int personId)
        {
            using (var context = new PeopleDbContext(_connectingString, _dropAndRecreateDatabase))
            {
                var dbPerson = context.People.FirstOrDefault(x => x.PersonId == personId);
                return DataModelMapper.MapToPersonDataModel(dbPerson);
            }
        }
    }
}

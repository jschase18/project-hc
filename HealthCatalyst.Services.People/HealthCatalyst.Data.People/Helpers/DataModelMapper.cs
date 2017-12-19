using HealthCatalyst.Data.People.Models;
using HealthCatalyst.Data.People.Schema;

namespace HealthCatalyst.Data.People.Helpers
{
    /// <summary>
    /// Maps entities to models returned by agents
    /// </summary>
    public static class DataModelMapper
    {
        public static AddressDataModel MapToAddressDataModel(Address dbAddress)
        {
            if(dbAddress == null)
            {
                return null;
            }

            return new AddressDataModel
            {
                Address1 = dbAddress.Address1,
                Address2 = dbAddress.Address2,
                City = dbAddress.City,
                Created = dbAddress.Created,
                Id = dbAddress.AddressId,
                PersonId = dbAddress.PersonId,
                PostalCode = dbAddress.PostalCode,
                StateId = dbAddress.StateId,
                Updated = dbAddress.Updated
            };
        }

        public static ContactMethodDataModel MapToContactMethodDataModel(ContactMethod dbContactMethod)
        {
            if(dbContactMethod == null)
            {
                return null;
            }

            return new ContactMethodDataModel
            {
                ContactMethodTypeId = dbContactMethod.ContactMethodTypeId,
                Created = dbContactMethod.Created,
                Id = dbContactMethod.ContactMethodId,
                PersonId = dbContactMethod.PersonId,
                Updated = dbContactMethod.Updated,
                Value = dbContactMethod.Value
            };
        }

        public static InterestDataModel MapToInterestDataModel(Interest dbInterest)
        {
            if(dbInterest == null)
            {
                return null;
            }

            return new InterestDataModel
            {
                Description = dbInterest.Description,
                Created = dbInterest.Created,
                Id = dbInterest.InterestId,
                PersonId = dbInterest.PersonId,
                Updated = dbInterest.Updated
            };
        }

        public static PersonDataModel MapToPersonDataModel(Person dbPerson)
        {
            if(dbPerson == null)
            {
                return null;
            }

            return new PersonDataModel
            {
                Age = dbPerson.Age,
                Created = dbPerson.Created,
                FirstName = dbPerson.FirstName,
                Id = dbPerson.PersonId,
                LastName = dbPerson.LastName,
                ProfilePictureUrl = dbPerson.ProfilePictureUrl,
                Updated = dbPerson.Updated
            };
        } 
    }
}

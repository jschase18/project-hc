using HealthCatalyst.Data.People.Models;
using HealthCatalyst.Services.People.Models;

namespace HealthCatalyst.Services.People.Helpers
{
    /// <summary>
    /// Data Model Mapper - Contains logic on how to map from service layer objects to data layer objects
    /// </summary>
    public class DataModelMapper
    {
        public static AddressDataModel MapToAddressDataModel(int personId, AddressModel address)
        {
            if(address == null)
            {
                return null;
            }

            return new AddressDataModel
            {
                Address1 = address.Address1,
                Address2 = address.Address2,
                City = address.City,
                Id = address.Id,
                PersonId = personId,
                PostalCode = address.PostalCode,
                StateId = address.StateId
            };
        }

        public static ContactMethodDataModel MapToContactMethodDataModel(int personId, ContactMethodModel contactMethod)
        {
            if (contactMethod == null)
            {
                return null;
            }

            return new ContactMethodDataModel
            {
                ContactMethodTypeId = contactMethod.ContactMethodTypeId,
                Id = contactMethod.Id,
                PersonId = personId,
                Value = contactMethod.Value
            };
        }

        public static InterestDataModel MapToInterestDataModel(int personId, InterestModel interest)
        {
            if (interest == null)
            {
                return null;
            }

            return new InterestDataModel
            {
                Description = interest.Description,
                Id = interest.Id,
                PersonId = personId
            };
        }

        public static PersonDataModel MapToPersonDataModel(PersonModel person)
        {
            if (person == null)
            {
                return null;
            }

            return new PersonDataModel
            {
                Age = person.Age,
                FirstName = person.FirstName,
                Id = person.Id,
                LastName = person.LastName,
                ProfilePictureUrl = person.ProfilePictureUrl
            };
        }
    }
}

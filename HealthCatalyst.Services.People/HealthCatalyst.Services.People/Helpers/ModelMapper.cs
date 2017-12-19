using System.Collections.Generic;
using System.Linq;
using HealthCatalyst.Data.People.Models;
using HealthCatalyst.Services.People.Models;

namespace HealthCatalyst.Services.People.Helpers
{
    /// <summary>
    /// Model Mapper - Contains logic on how to map from data layer objects to service layer objects
    /// </summary>
    public class ModelMapper
    {
        public static AddressModel MapToAddressModel(AddressDataModel addressData)
        {
            if (addressData == null)
            {
                return null;
            }

            return new AddressModel
            {
                Address1 = addressData.Address1,
                Address2 = addressData.Address2,
                City = addressData.City,
                Id = addressData.Id,
                PostalCode = addressData.PostalCode,
                StateId = addressData.StateId
            };
        }

        public static ContactMethodModel MapToContactMethodModel(ContactMethodDataModel contactMethodData)
        {
            if (contactMethodData == null)
            {
                return null;
            }

            return new ContactMethodModel
            {
                ContactMethodTypeId = contactMethodData.ContactMethodTypeId,
                Id = contactMethodData.Id,
                Value = contactMethodData.Value
            };
        }

        public static InterestModel MapToInterestModel(InterestDataModel interestData)
        {
            if (interestData == null)
            {
                return null;
            }

            return new InterestModel
            {
                Description = interestData.Description,
                Id = interestData.Id
            };
        }

        public static PersonDetailModel MapToPersonDetailModel(PersonDataModel personData, List<AddressDataModel> addressData, List<ContactMethodDataModel> contactMethodData, List<InterestDataModel> interestData)
        {
            if (personData == null)
            {
                return null;
            }

            if (addressData == null)
            {
                addressData = new List<AddressDataModel>();
            }

            if (contactMethodData == null)
            {
                contactMethodData = new List<ContactMethodDataModel>();
            }

            if (interestData == null)
            {
                interestData = new List<InterestDataModel>();
            }

            return new PersonDetailModel
            {
                Age = personData.Age,
                FirstName = personData.FirstName,
                Id = personData.Id,
                LastName = personData.LastName,
                ProfilePictureUrl = personData.ProfilePictureUrl,
                Addresses = addressData.Select(MapToAddressModel).ToList(),
                ContactMethods = contactMethodData.Select(MapToContactMethodModel).ToList(),
                Interests = interestData.Select(MapToInterestModel).ToList()
            };
        }

        public static PersonModel MapToPersonModel(PersonDataModel personData)
        {
            if (personData == null)
            {
                return null;
            }

            return new PersonModel
            {
                Age = personData.Age,
                FirstName = personData.FirstName,
                Id = personData.Id,
                LastName = personData.LastName,
                ProfilePictureUrl = personData.ProfilePictureUrl
            };
        }
    }
}

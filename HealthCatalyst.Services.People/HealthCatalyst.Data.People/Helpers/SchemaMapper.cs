using System;
using HealthCatalyst.Data.People.Models;
using HealthCatalyst.Data.People.Schema;

namespace HealthCatalyst.Data.People.Helpers
{
    /// <summary>
    /// Prepares entities for updating or adding to the DB context
    /// </summary>
    public static class SchemaMapper
    {
        public static Address MapToSchemaAddress(this Address dbAddress, AddressDataModel addressData)
        {
            if (dbAddress == null)
            {
                dbAddress = new Address
                {
                    Created = DateTimeOffset.UtcNow
                };
            }

            dbAddress.Address1 = addressData.Address1;
            dbAddress.Address2 = addressData.Address2;
            dbAddress.AddressId = addressData.Id;
            dbAddress.City = addressData.City;
            dbAddress.Created = dbAddress.Created; // persist created date
            dbAddress.Person = null;
            dbAddress.PersonId = addressData.PersonId;
            dbAddress.PostalCode = addressData.PostalCode;
            dbAddress.State = null;
            dbAddress.StateId = addressData.StateId;
            dbAddress.Updated = DateTimeOffset.UtcNow;

            return dbAddress;
        }

        public static ContactMethod MapToSchemaContactMethod(this ContactMethod dbContactMethod, ContactMethodDataModel contactMethodData)
        {
            if (dbContactMethod == null)
            {
                dbContactMethod = new ContactMethod
                {
                    Created = DateTimeOffset.UtcNow
                };
            }

            dbContactMethod.ContactMethodId = contactMethodData.Id;
            dbContactMethod.ContactMethodType = null;
            dbContactMethod.ContactMethodTypeId = contactMethodData.ContactMethodTypeId;
            dbContactMethod.Created = dbContactMethod.Created; // persist created date
            dbContactMethod.Person = null;
            dbContactMethod.PersonId = contactMethodData.PersonId;
            dbContactMethod.Updated = DateTimeOffset.UtcNow;
            dbContactMethod.Value = contactMethodData.Value;

            return dbContactMethod;
        }

        public static Interest MapToSchemaInterest(this Interest dbInterest, InterestDataModel interestDataModel)
        {
            if (dbInterest == null)
            {
                dbInterest = new Interest
                {
                    Created = DateTimeOffset.UtcNow
                };
            }

            dbInterest.Created = dbInterest.Created; // persist created date
            dbInterest.Description = interestDataModel.Description;
            dbInterest.InterestId = interestDataModel.Id;
            dbInterest.Person = null;
            dbInterest.PersonId = interestDataModel.PersonId;
            dbInterest.Updated = DateTimeOffset.UtcNow;
            
            return dbInterest;
        }

        public static Person MapToSchemaPerson(this Person dbPerson, PersonDataModel personData)
        {
            if (dbPerson == null)
            {
                dbPerson = new Person
                {
                    Created = DateTimeOffset.UtcNow
                };
            }

            dbPerson.Addresses = null;
            dbPerson.Age = personData.Age;
            dbPerson.ContactMethods = null;
            dbPerson.Created = dbPerson.Created; // persist created date
            dbPerson.FirstName = personData.FirstName;
            dbPerson.Interests = null;
            dbPerson.LastName = personData.LastName;
            dbPerson.PersonId = personData.Id;
            dbPerson.ProfilePictureUrl = personData.ProfilePictureUrl;
            dbPerson.Updated = DateTimeOffset.UtcNow;

            return dbPerson;
        }
    }
}

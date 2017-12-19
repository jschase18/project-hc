using HealthCatalyst.Data.People.Models;
using HealthCatalyst.Data.People.Schema;
using HealthCatalyst.Data.People.Helpers;
using NUnit.Framework;
using System;

namespace HealthCatalyst.Data.People.Tests.Helpers
{
    [TestFixture]
    public class SchemaMapperTests
    {
        [Test]
        public void MapToSchemaAddress_MapsToNewRecord()
        {
            // Arrange
            var addressData = new AddressDataModel
            {
                Address1 = "123 Test Street",
                Address2 = "Suite 100",
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                City = "TestVille",
                Id = 0,
                PersonId = 100,
                PostalCode = "88888",
                StateId = 1,
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            };

            Address dbAddress = null;

            // Act
            dbAddress = dbAddress.MapToSchemaAddress(addressData);

            // Assert
            Assert.IsNotNull(dbAddress);
            Assert.AreEqual(addressData.Address1, dbAddress.Address1);
            Assert.AreEqual(addressData.Address2, dbAddress.Address2);
            Assert.AreEqual(addressData.Id, dbAddress.AddressId);
            Assert.AreEqual(addressData.City, dbAddress.City);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbAddress.Created.Date);
            Assert.IsNull(dbAddress.Person);
            Assert.AreEqual(addressData.PersonId, dbAddress.PersonId);
            Assert.AreEqual(addressData.PostalCode, dbAddress.PostalCode);
            Assert.IsNull(dbAddress.State);
            Assert.AreEqual(addressData.StateId, dbAddress.StateId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbAddress.Updated.Date);
        }

        [Test]
        public void MapToSchemaAddress_CorrectlyMapsToExistingRecord()
        {
            // Arrange
            var addressData = new AddressDataModel
            {
                Address1 = "123 Test Street Updated",
                Address2 = "Suite 100 Updated",
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                City = "TestVille Updated",
                Id = 1000,
                PersonId = 100,
                PostalCode = "77777",
                StateId = 1,
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            };

            var dbAddress = new Address
            {
                Address1 = "123 Test Street",
                Address2 = "Suite 100",
                AddressId = 1000,
                City = "Test Ville",
                Created = DateTimeOffset.UtcNow,
                Person = null,
                PersonId = 100,
                PostalCode = "88888",
                State = null,
                StateId = 25,
                Updated = DateTimeOffset.UtcNow
            };

            // Act
            dbAddress = dbAddress.MapToSchemaAddress(addressData);

            // Assert
            Assert.IsNotNull(dbAddress);
            Assert.AreEqual(addressData.Address1, dbAddress.Address1);
            Assert.AreEqual(addressData.Address2, dbAddress.Address2);
            Assert.AreEqual(addressData.Id, dbAddress.AddressId);
            Assert.AreEqual(addressData.City, dbAddress.City);
            Assert.AreNotEqual(addressData.Created, dbAddress.Created);
            Assert.IsNull(dbAddress.Person);
            Assert.AreEqual(addressData.PersonId, dbAddress.PersonId);
            Assert.AreEqual(addressData.PostalCode, dbAddress.PostalCode);
            Assert.IsNull(dbAddress.State);
            Assert.AreEqual(addressData.StateId, dbAddress.StateId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbAddress.Updated.Date);
        }

        [Test]
        public void MapToSchemaContactMethod_MapsToNewRecord()
        {
            // Arrange
            var contactMethodData = new ContactMethodDataModel
            {
                ContactMethodTypeId = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                Id = 0,
                PersonId = 100,
                Updated = DateTimeOffset.Now.AddDays(-10),
                Value = "801-555-1234"
            };

            ContactMethod dbContactMethod = null;

            // Act
            dbContactMethod = dbContactMethod.MapToSchemaContactMethod(contactMethodData);

            // Assert
            Assert.IsNotNull(dbContactMethod);
            Assert.AreEqual(contactMethodData.Id, dbContactMethod.ContactMethodId);
            Assert.IsNull(dbContactMethod.ContactMethodType);
            Assert.AreEqual(contactMethodData.ContactMethodTypeId, dbContactMethod.ContactMethodTypeId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbContactMethod.Created.Date);
            Assert.IsNull(dbContactMethod.Person);
            Assert.AreEqual(contactMethodData.PersonId, dbContactMethod.PersonId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbContactMethod.Updated.Date);
            Assert.AreEqual(contactMethodData.Value, dbContactMethod.Value);
        }

        [Test]
        public void MapToSchemaContactMethod_CorrectlyMapsToExistingRecord()
        {
            // Arrange
            var contactMethodData = new ContactMethodDataModel
            {
                ContactMethodTypeId = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                Id = 1000,
                PersonId = 100,
                Updated = DateTimeOffset.Now.AddDays(-10),
                Value = "801-555-1234"
            };

            var dbContactMethod = new ContactMethod
            {
                ContactMethodId = 1000,
                ContactMethodType = null,
                ContactMethodTypeId = 2,
                Created = DateTimeOffset.UtcNow,
                Person = null,
                PersonId = 100,
                Updated = DateTimeOffset.UtcNow,
                Value = "email@testing.com"
            };

            // Act
            dbContactMethod = dbContactMethod.MapToSchemaContactMethod(contactMethodData);

            // Assert
            Assert.IsNotNull(dbContactMethod);
            Assert.AreEqual(contactMethodData.Id, dbContactMethod.ContactMethodId);
            Assert.IsNull(dbContactMethod.ContactMethodType);
            Assert.AreEqual(contactMethodData.ContactMethodTypeId, dbContactMethod.ContactMethodTypeId);
            Assert.AreNotEqual(contactMethodData.Created, dbContactMethod.Created);
            Assert.IsNull(dbContactMethod.Person);
            Assert.AreEqual(contactMethodData.PersonId, dbContactMethod.PersonId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbContactMethod.Updated.Date);
            Assert.AreEqual(contactMethodData.Value, dbContactMethod.Value);
        }

        [Test]
        public void MapToSchemaInterest_MapsToNewRecord()
        {
            // Arrange
            var interestData = new InterestDataModel
            {
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                Description = "Testing",
                Id = 0,
                PersonId = 100,
                Updated = DateTimeOffset.Now.AddDays(-10),
            };

            Interest dbInterest = null;

            // Act
            dbInterest = dbInterest.MapToSchemaInterest(interestData);

            // Assert
            Assert.IsNotNull(dbInterest);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbInterest.Created.Date);
            Assert.AreEqual(interestData.Description, dbInterest.Description);
            Assert.AreEqual(interestData.Id, dbInterest.InterestId);
            Assert.IsNull(dbInterest.Person);
            Assert.AreEqual(interestData.PersonId, dbInterest.PersonId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbInterest.Updated.Date);
        }

        [Test]
        public void MapToSchemaInterest_CorrectlyMapsToExistingRecord()
        {
            // Arrange
            var interestData = new InterestDataModel
            {
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                Description = "Testing",
                Id = 1000,
                PersonId = 100,
                Updated = DateTimeOffset.Now.AddDays(-10),
            };

            var dbInterest = new Interest
            {
                Created = DateTimeOffset.UtcNow,
                Description = "Testing Update",
                InterestId = 1000,
                Person = null,
                PersonId = 100,
                Updated = DateTimeOffset.UtcNow
            };

            // Act
            dbInterest = dbInterest.MapToSchemaInterest(interestData);

            // Assert
            Assert.IsNotNull(dbInterest);
            Assert.AreNotEqual(interestData.Created, dbInterest.Created);
            Assert.AreEqual(interestData.Description, dbInterest.Description);
            Assert.AreEqual(interestData.Id, dbInterest.InterestId);
            Assert.IsNull(dbInterest.Person);
            Assert.AreEqual(interestData.PersonId, dbInterest.PersonId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbInterest.Updated.Date);
        }

        [Test]
        public void MapToSchemaPerson_MapsToNewRecord()
        {
            // Arrange
            var personData = new PersonDataModel
            {
                Age = 30,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            };

            Person dbPerson = null;

            // Act
            dbPerson = dbPerson.MapToSchemaPerson(personData);

            // Assert
            Assert.IsNotNull(dbPerson);
            Assert.AreEqual(personData.Age, dbPerson.Age);
            Assert.IsNull(dbPerson.Addresses);
            Assert.IsNull(dbPerson.ContactMethods);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbPerson.Created.Date);
            Assert.AreEqual(personData.FirstName, dbPerson.FirstName);
            Assert.IsNull(dbPerson.Interests);
            Assert.AreEqual(personData.LastName, dbPerson.LastName);
            Assert.AreEqual(personData.Id, dbPerson.PersonId);
            Assert.AreEqual(personData.ProfilePictureUrl, dbPerson.ProfilePictureUrl);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbPerson.Updated.Date);
        }

        [Test]
        public void MapToSchemaPerson_CorrectlyMapsToExistingRecord()
        {
            // Arrange
            var personData = new PersonDataModel
            {
                Age = 30,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 100,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            };

            var dbPerson = new Person
            {
                Addresses = null,
                Age = 30,
                ContactMethods = null,
                Created = DateTimeOffset.UtcNow,
                FirstName = "John",
                Interests = null,
                LastName = "Smith",
                PersonId = 100,
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow
            };

            // Act
            dbPerson = dbPerson.MapToSchemaPerson(personData);

            // Assert
            Assert.IsNotNull(dbPerson);
            Assert.AreEqual(personData.Age, dbPerson.Age);
            Assert.IsNull(dbPerson.Addresses);
            Assert.IsNull(dbPerson.ContactMethods);
            Assert.AreNotEqual(personData.Created, dbPerson.Created);
            Assert.AreEqual(personData.FirstName, dbPerson.FirstName);
            Assert.IsNull(dbPerson.Interests);
            Assert.AreEqual(personData.LastName, dbPerson.LastName);
            Assert.AreEqual(personData.Id, dbPerson.PersonId);
            Assert.AreEqual(personData.ProfilePictureUrl, dbPerson.ProfilePictureUrl);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, dbPerson.Updated.Date);
        }
    }
}

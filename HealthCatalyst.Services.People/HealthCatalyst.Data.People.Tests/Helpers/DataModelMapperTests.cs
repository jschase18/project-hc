using HealthCatalyst.Data.People.Helpers;
using HealthCatalyst.Data.People.Schema;
using NUnit.Framework;
using System;

namespace HealthCatalyst.Data.People.Tests.Helpers
{
    [TestFixture]
    public class DataModelMapperTests
    {
        [Test]
        public void MapToAddressDataModel_MapsToNull()
        {
            // Arrange
            Address dbAddress = null;

            // Act
            var addressData = DataModelMapper.MapToAddressDataModel(dbAddress);

            // Assert
            Assert.IsNull(addressData);
        }

        [Test] 
        public void MapToAddressDataModel_CorrectlyMapsFromSchemaModel()
        {
            // Arrange
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
            var addressData = DataModelMapper.MapToAddressDataModel(dbAddress);

            // Assert
            Assert.IsNotNull(addressData);
            Assert.AreEqual(dbAddress.Address1, addressData.Address1);
            Assert.AreEqual(dbAddress.Address2, addressData.Address2);
            Assert.AreEqual(dbAddress.Created, addressData.Created);
            Assert.AreEqual(dbAddress.City, addressData.City);
            Assert.AreEqual(dbAddress.AddressId, addressData.Id);
            Assert.AreEqual(dbAddress.PersonId, addressData.PersonId);
            Assert.AreEqual(dbAddress.PostalCode, addressData.PostalCode);
            Assert.AreEqual(dbAddress.StateId, addressData.StateId);
            Assert.AreEqual(dbAddress.Updated, addressData.Updated);
        }

        [Test]
        public void MapToContactMethodDataModel_MapsToNull()
        {
            // Arrange
            ContactMethod dbContactMethod = null;

            // Act
            var contactMethodData = DataModelMapper.MapToContactMethodDataModel(dbContactMethod);

            // Assert
            Assert.IsNull(contactMethodData);
        }

        [Test]
        public void MapToContactMethodDataModel_CorrectlyMapsFromSchemaModel()
        {
            // Arrange
            var dbContactMethod = new ContactMethod
            {
                ContactMethodId = 1000,
                ContactMethodType = null,
                ContactMethodTypeId = 1,
                Created = DateTimeOffset.UtcNow,
                Person = null,
                PersonId = 100,
                Updated = DateTimeOffset.UtcNow,
                Value = "801-555-1234"
            };

            // Act
            var contactMethodData = DataModelMapper.MapToContactMethodDataModel(dbContactMethod);

            // Assert
            Assert.IsNotNull(contactMethodData);
            Assert.AreEqual(dbContactMethod.ContactMethodTypeId, contactMethodData.ContactMethodTypeId);
            Assert.AreEqual(dbContactMethod.Created, contactMethodData.Created);
            Assert.AreEqual(dbContactMethod.ContactMethodId, contactMethodData.Id);
            Assert.AreEqual(dbContactMethod.PersonId, contactMethodData.PersonId);
            Assert.AreEqual(dbContactMethod.Updated, contactMethodData.Updated);
            Assert.AreEqual(dbContactMethod.Value, contactMethodData.Value);
        }

        [Test]
        public void MapToInterestDataModel_MapsToNull()
        {
            // Arrange
            Interest dbInterest = null;

            // Act
            var interestData = DataModelMapper.MapToInterestDataModel(dbInterest);

            // Assert
            Assert.IsNull(interestData);
        }

        [Test]
        public void MapToInterestDataModel_CorrectlyMapsFromSchemaModel()
        {
            // Arrange
            var dbInterest = new Interest
            {
                Created = DateTimeOffset.UtcNow,
                Description = "Testing",
                InterestId = 1000,
                Person = null,
                PersonId = 100,
                Updated = DateTimeOffset.UtcNow
            };

            // Act
            var interestData = DataModelMapper.MapToInterestDataModel(dbInterest);

            // Assert
            Assert.IsNotNull(interestData);
            Assert.AreEqual(dbInterest.Created, interestData.Created);
            Assert.AreEqual(dbInterest.Description, interestData.Description);
            Assert.AreEqual(dbInterest.InterestId, interestData.Id);
            Assert.AreEqual(dbInterest.PersonId, interestData.PersonId);
            Assert.AreEqual(dbInterest.Updated, interestData.Updated);
        }

        [Test]
        public void MapToPersonDataModel_MapsToNull()
        {
            // Arrange
            Person dbPerson = null;

            // Act
            var personData = DataModelMapper.MapToPersonDataModel(dbPerson);

            // Assert
            Assert.IsNull(personData);
        }

        [Test]
        public void MapToPersonDataModel_CorrectlyMapsFromSchemaModel()
        {
            // Arrange
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
            var personData = DataModelMapper.MapToPersonDataModel(dbPerson);

            // Assert
            Assert.IsNotNull(personData);
            Assert.AreEqual(dbPerson.Age, personData.Age);
            Assert.AreEqual(dbPerson.Created, personData.Created);
            Assert.AreEqual(dbPerson.FirstName, personData.FirstName);
            Assert.AreEqual(dbPerson.PersonId, personData.Id);
            Assert.AreEqual(dbPerson.LastName, personData.LastName);
            Assert.AreEqual(dbPerson.ProfilePictureUrl, personData.ProfilePictureUrl);
            Assert.AreEqual(dbPerson.Updated, personData.Updated);
        }
    }
}

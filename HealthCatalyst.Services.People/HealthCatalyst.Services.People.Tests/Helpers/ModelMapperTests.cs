using HealthCatalyst.Data.People.Models;
using HealthCatalyst.Services.People.Helpers;
using NUnit.Framework;
using System;

namespace HealthCatalyst.Services.People.Tests.Helpers
{
    [TestFixture]
    public class ModelMapperTests
    {
        [Test]
        public void MapToAddressModel_MapsToNull()
        {
            // Arrange
            AddressDataModel addressData = null;

            // Act
            var address = ModelMapper.MapToAddressModel(addressData);

            // Assert
            Assert.IsNull(address);
        }

        [Test]
        public void MapToAddressModel_CorrectlyMapsFromDataModel()
        {
            // Arrange
            var addressData = new AddressDataModel
            {
                Address1 = "123 Test Street",
                Address2 = "Suite 100",
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                City = "TestVille",
                Id = 1000,
                PersonId = 100,
                PostalCode = "88888",
                StateId = 1,
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            };

            // Act
            var address = ModelMapper.MapToAddressModel(addressData);

            // Assert
            Assert.IsNotNull(address);
            Assert.AreEqual(addressData.Address1, address.Address1);
            Assert.AreEqual(addressData.Address2, address.Address2);
            Assert.AreEqual(addressData.City, address.City);
            Assert.AreEqual(addressData.Id, address.Id);
            Assert.AreEqual(addressData.PostalCode, address.PostalCode);
            Assert.AreEqual(addressData.StateId, address.StateId);
        }

        [Test]
        public void MapToContactMethodModel_MapsToNull()
        {
            // Arrange
            ContactMethodDataModel contactMethodData = null;

            // Act
            var contactMethod = ModelMapper.MapToContactMethodModel(contactMethodData);

            // Assert
            Assert.IsNull(contactMethod);
        }

        [Test]
        public void MapToContactMethodModel_CorrectlyMapsFromDataModel()
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

            // Act
            var contactMethod = ModelMapper.MapToContactMethodModel(contactMethodData);

            // Assert
            Assert.IsNotNull(contactMethod);
            Assert.AreEqual(contactMethodData.ContactMethodTypeId, contactMethod.ContactMethodTypeId);
            Assert.AreEqual(contactMethodData.Id, contactMethod.Id);
            Assert.AreEqual(contactMethodData.Value, contactMethod.Value);
        }

        [Test]
        public void MapToInterestModel_MapsToNull()
        {
            // Arrange
            InterestDataModel interestData = null;

            // Act
            var interest = ModelMapper.MapToInterestModel(interestData);

            // Assert
            Assert.IsNull(interest);
        }

        [Test]
        public void MapToInterestModel_CorrectlyMapsFromDataModel()
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

            // Act
            var interest = ModelMapper.MapToInterestModel(interestData);

            // Assert
            Assert.IsNotNull(interest);
            Assert.AreEqual(interestData.Description, interest.Description);
            Assert.AreEqual(interestData.Id, interest.Id);
        }

        [Test]
        public void MapToPersonDetailModel_MapsToNull()
        {
            // Arrange
            PersonDataModel personData = null;

            // Act
            var personDetail = ModelMapper.MapToPersonDetailModel(personData, null, null, null);

            // Assert
            Assert.IsNull(personDetail);
        }

        [Test]
        public void MapToPersonDetailModel_CorrectlyMapsFromDataModel()
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

            // Act
            var personDetail = ModelMapper.MapToPersonDetailModel(personData, null, null, null);

            // Assert
            Assert.IsNotNull(personDetail);
            Assert.IsEmpty(personDetail.Addresses);
            Assert.AreEqual(personData.Age, personDetail.Age);
            Assert.IsEmpty(personDetail.ContactMethods);
            Assert.AreEqual(personData.FirstName, personDetail.FirstName);
            Assert.AreEqual(personData.Id, personDetail.Id);
            Assert.IsEmpty(personDetail.Interests);
            Assert.AreEqual(personData.LastName, personDetail.LastName);
            Assert.AreEqual(personData.ProfilePictureUrl, personDetail.ProfilePictureUrl);
        }

        [Test]
        public void MapToPersonModel_MapsToNull()
        {
            // Arrange
            PersonDataModel personData = null;

            // Act
            var person = ModelMapper.MapToPersonModel(personData);

            // Assert
            Assert.IsNull(person);
        }

        [Test]
        public void MapToPersonModel_CorrectlyMapsFromDataModel()
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

            // Act
            var person = ModelMapper.MapToPersonModel(personData);

            // Assert
            Assert.IsNotNull(person);
            Assert.AreEqual(personData.Age, person.Age);
            Assert.AreEqual(personData.FirstName, person.FirstName);
            Assert.AreEqual(personData.Id, person.Id);
            Assert.AreEqual(personData.LastName, person.LastName);
            Assert.AreEqual(personData.ProfilePictureUrl, person.ProfilePictureUrl);
        }
    }
}

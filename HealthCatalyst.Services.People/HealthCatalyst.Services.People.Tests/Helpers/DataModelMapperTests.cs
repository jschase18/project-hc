using HealthCatalyst.Services.People.Helpers;
using HealthCatalyst.Services.People.Models;
using NUnit.Framework;

namespace HealthCatalyst.Services.People.Tests.Helpers
{
    [TestFixture]
    public class DataModelMapperTests
    {
        [Test]
        public void MapToAddressDataModel_MapsToNull()
        {
            // Arrange
            var personId = 100;
            AddressModel address = null;

            // Act
            var addressData = DataModelMapper.MapToAddressDataModel(personId, address);

            // Assert
            Assert.IsNull(addressData);
        }

        [Test]
        public void MapToAddressDataModel_CorrectlyMapsFromServiceModel()
        {
            // Arrange
            var personId = 100;
            var address = new AddressModel
            {
                Address1 = "123 Test Street",
                Address2 = "Suite 100",
                City = "TestVille",
                Id = 1000,
                PostalCode = "88888",
                StateId = 1
            };

            // Act
            var addressData = DataModelMapper.MapToAddressDataModel(personId, address);

            // Assert
            Assert.IsNotNull(addressData);
            Assert.AreEqual(address.Address1, addressData.Address1);
            Assert.AreEqual(address.Address2, addressData.Address2);
            Assert.AreEqual(address.City, addressData.City);
            Assert.AreEqual(address.Id, addressData.Id);
            Assert.AreEqual(personId, addressData.PersonId);
            Assert.AreEqual(address.PostalCode, addressData.PostalCode);
            Assert.AreEqual(address.StateId, addressData.StateId);
        }

        [Test]
        public void MapToContactMethodDataModel_MapsToNull()
        {
            // Arrange
            var personId = 100;
            ContactMethodModel contactMethod = null;

            // Act
            var contactMethodData = DataModelMapper.MapToContactMethodDataModel(personId, contactMethod);

            // Assert
            Assert.IsNull(contactMethodData);
        }

        [Test]
        public void MapToContactMethodDataModel_CorrectlyMapsFromServiceModel()
        {
            // Arrange
            var personId = 100;
            var contactMethod = new ContactMethodModel
            {
                ContactMethodTypeId = 1,
                Id = 1000,
                Value = "801-555-1234"
            }; ;

            // Act
            var contactMethodData = DataModelMapper.MapToContactMethodDataModel(personId, contactMethod);

            // Assert
            Assert.IsNotNull(contactMethodData);
            Assert.AreEqual(contactMethod.ContactMethodTypeId, contactMethodData.ContactMethodTypeId);
            Assert.AreEqual(contactMethod.Id, contactMethodData.Id);
            Assert.AreEqual(personId, contactMethodData.PersonId);
            Assert.AreEqual(contactMethod.Value, contactMethodData.Value);
        }

        [Test]
        public void MapToInterestDataModel_MapsToNull()
        {
            // Arrange
            var personId = 100;
            InterestModel interest = null;

            // Act
            var interestData = DataModelMapper.MapToInterestDataModel(personId, interest);

            // Assert
            Assert.IsNull(interestData);
        }

        [Test]
        public void MapToInterestDataModel_CorrectlyMapsFromServiceModel()
        {
            // Arrange
            var personId = 100;
            var interest = new InterestModel
            {
                Description = "Testing",
                Id = 1000
            };

            // Act
            var interestData = DataModelMapper.MapToInterestDataModel(personId, interest);

            // Assert
            Assert.IsNotNull(interestData);
            Assert.AreEqual(interest.Description, interestData.Description);
            Assert.AreEqual(interest.Id, interestData.Id);
            Assert.AreEqual(personId, interestData.PersonId);
        }

        [Test]
        public void MapToPersonDataModel_MapsToNull()
        {
            // Arrange
            PersonModel person = null;

            // Act
            var personData = DataModelMapper.MapToPersonDataModel(person);

            // Assert
            Assert.IsNull(personData);
        }

        [Test]
        public void MapToPersonDataModel_CorrectlyMapsFromServiceModel()
        {
            // Arrange
            var person = new PersonModel
            {
                Age = 30,
                FirstName = "John",
                Id = 1000,
                LastName = "Smith",
                ProfilePictureUrl = "test.png"
            };

            // Act
            var personData = DataModelMapper.MapToPersonDataModel(person);

            // Assert
            Assert.IsNotNull(personData);
            Assert.AreEqual(person.Age, personData.Age);
            Assert.AreEqual(person.FirstName, personData.FirstName);
            Assert.AreEqual(person.Id, personData.Id);
            Assert.AreEqual(person.LastName, personData.LastName);
            Assert.AreEqual(person.ProfilePictureUrl, personData.ProfilePictureUrl);
        }
    }
}

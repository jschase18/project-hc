using HealthCatalyst.Data.People.Agents;
using HealthCatalyst.Data.People.Interfaces;
using HealthCatalyst.Data.People.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace HealthCatalyst.Data.People.Tests.Agents
{
    [TestFixture]
    public class PersonDataAgentTests
    {
        private const string TEST_CONNECTION_STRING = "Data Source=localhost;Initial Catalog=PeopleTests_DAD891B8F4B449F780625720F14D7A91;Trusted_Connection=True;MultipleActiveResultSets=True;";

        [Test]
        public void InsertOrUpdateAddress_InsertAddress()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personData = agent.InsertOrUpdatePerson(new PersonDataModel
            {
                Age = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            var addressData = new AddressDataModel
            {
                Address1 = "123 Test Street",
                Address2 = "Suite 100",
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                City = "TestVille",
                Id = 0,
                PersonId = personData.Id,
                PostalCode = "88888",
                StateId = 1,
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            };

            // Act
            var addressDataSaved = agent.InsertOrUpdateAddress(addressData);

            // Assert
            Assert.IsNotNull(addressDataSaved);
            Assert.AreEqual(addressData.Address1, addressDataSaved.Address1);
            Assert.AreEqual(addressData.Address2, addressDataSaved.Address2);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, addressDataSaved.Created.Date);
            Assert.AreEqual(addressData.City, addressDataSaved.City);
            Assert.IsTrue(addressDataSaved.Id > 0);
            Assert.AreEqual(addressData.PersonId, addressDataSaved.PersonId);
            Assert.AreEqual(addressData.PostalCode, addressDataSaved.PostalCode);
            Assert.AreEqual(addressData.StateId, addressDataSaved.StateId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, addressDataSaved.Updated.Date);
        }

        [Test]
        public void InsertOrUpdateAddress_UpdateAddress()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personData = agent.InsertOrUpdatePerson(new PersonDataModel
            {
                Age = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            var addressData = agent.InsertOrUpdateAddress(new AddressDataModel
            {
                Address1 = "123 Test Street",
                Address2 = "Suite 100",
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                City = "TestVille",
                Id = 0,
                PersonId = personData.Id,
                PostalCode = "88888",
                StateId = 1,
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            addressData = new AddressDataModel
            {
                Address1 = "123 Test Street Updted",
                Address2 = "Suite 100 Updated",
                Created = addressData.Created,
                City = "TestVille Updated",
                Id = addressData.Id,
                PersonId = personData.Id,
                PostalCode = "77777",
                StateId = 25,
                Updated = addressData.Updated
            };

            // Act
            var addressDataSaved = agent.InsertOrUpdateAddress(addressData);

            // Assert
            Assert.IsNotNull(addressDataSaved);
            Assert.AreEqual(addressData.Address1, addressDataSaved.Address1);
            Assert.AreEqual(addressData.Address2, addressDataSaved.Address2);
            Assert.AreEqual(addressData.Created, addressDataSaved.Created);
            Assert.AreEqual(addressData.City, addressDataSaved.City);
            Assert.AreEqual(addressData.Id, addressDataSaved.Id);
            Assert.AreEqual(addressData.PersonId, addressDataSaved.PersonId);
            Assert.AreEqual(addressData.PostalCode, addressDataSaved.PostalCode);
            Assert.AreEqual(addressData.StateId, addressDataSaved.StateId);
            Assert.IsTrue(addressData.Updated < addressDataSaved.Updated.Date);
        }

        [Test]
        public void InsertOrUpdateContactMethod_InsertContactMethod()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personData = agent.InsertOrUpdatePerson(new PersonDataModel
            {
                Age = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            var contactMethodData = new ContactMethodDataModel
            {
                ContactMethodTypeId = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                Id = 0,
                PersonId = personData.Id,
                Updated = DateTimeOffset.Now.AddDays(-10),
                Value = "801-555-1234"
            };

            // Act
            var contactMethodDataSaved = agent.InsertOrUpdateContactMethod(contactMethodData);

            // Assert
            Assert.IsNotNull(contactMethodDataSaved);
            Assert.AreEqual(contactMethodData.ContactMethodTypeId, contactMethodDataSaved.ContactMethodTypeId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, contactMethodDataSaved.Created.Date);
            Assert.IsTrue(contactMethodDataSaved.Id > 0);
            Assert.AreEqual(contactMethodData.PersonId, contactMethodDataSaved.PersonId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, contactMethodDataSaved.Updated.Date);
            Assert.AreEqual(contactMethodData.Value, contactMethodDataSaved.Value);
        }

        [Test]
        public void InsertOrUpdateContactMethod_UpdateContactMethod()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personData = agent.InsertOrUpdatePerson(new PersonDataModel
            {
                Age = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            var contactMethodData = agent.InsertOrUpdateContactMethod(new ContactMethodDataModel
            {
                ContactMethodTypeId = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                Id = 0,
                PersonId = personData.Id,
                Updated = DateTimeOffset.Now.AddDays(-10),
                Value = "801-555-1234"
            });

            contactMethodData = new ContactMethodDataModel
            {
                ContactMethodTypeId = 2,
                Created = contactMethodData.Created,
                Id = contactMethodData.Id,
                PersonId = personData.Id,
                Updated = contactMethodData.Updated,
                Value = "john.smith@test.com"
            };

            // Act
            var contactMethodDataSaved = agent.InsertOrUpdateContactMethod(contactMethodData);

            // Assert
            Assert.IsNotNull(contactMethodDataSaved);
            Assert.AreEqual(contactMethodData.ContactMethodTypeId, contactMethodDataSaved.ContactMethodTypeId);
            Assert.AreEqual(contactMethodData.Created, contactMethodDataSaved.Created);
            Assert.AreEqual(contactMethodData.Id, contactMethodDataSaved.Id);
            Assert.AreEqual(contactMethodData.PersonId, contactMethodDataSaved.PersonId);
            Assert.IsTrue(contactMethodData.Updated < contactMethodDataSaved.Updated.Date);
            Assert.AreEqual(contactMethodData.Value, contactMethodDataSaved.Value);
        }
        
        [Test]
        public void InsertOrUpdateInterest_InsertInterest()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personData = agent.InsertOrUpdatePerson(new PersonDataModel
            {
                Age = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            var interestData = new InterestDataModel
            {
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                Description = "Testing",
                Id = 0,
                PersonId = personData.Id,
                Updated = DateTimeOffset.Now.AddDays(-10),
            };

            // Act
            var interestDataSaved = agent.InsertOrUpdateInterest(interestData);

            // Assert
            Assert.IsNotNull(interestDataSaved);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, interestDataSaved.Created.Date);
            Assert.AreEqual(interestData.Description, interestDataSaved.Description);
            Assert.IsTrue(interestDataSaved.Id > 0);
            Assert.AreEqual(interestData.PersonId, interestDataSaved.PersonId);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, interestDataSaved.Updated.Date);
        }

        [Test]
        public void InsertOrUpdateInterest_UpdateInterest()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personData = agent.InsertOrUpdatePerson(new PersonDataModel
            {
                Age = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            var interestData = agent.InsertOrUpdateInterest(new InterestDataModel
            {
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                Description = "Testing",
                Id = 0,
                PersonId = personData.Id,
                Updated = DateTimeOffset.Now.AddDays(-10),
            });

            interestData = new InterestDataModel
            {
                Created = interestData.Created,
                Description = "Testing Updated",
                Id = interestData.Id,
                PersonId = personData.Id,
                Updated = interestData.Updated,
            };

            // Act
            var interestDataSaved = agent.InsertOrUpdateInterest(interestData);

            // Assert
            Assert.IsNotNull(interestDataSaved);
            Assert.AreEqual(interestData.Created, interestDataSaved.Created);
            Assert.AreEqual(interestData.Description, interestDataSaved.Description);
            Assert.AreEqual(interestData.Id, interestDataSaved.Id);
            Assert.AreEqual(interestData.PersonId, interestDataSaved.PersonId);
            Assert.IsTrue(interestData.Updated < interestDataSaved.Updated);
        }

        [Test]
        public void InsertOrUpdatePerson_InsertPerson()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
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

            // Act
            var personDataSaved = agent.InsertOrUpdatePerson(personData);

            // Assert
            Assert.IsNotNull(personDataSaved);
            Assert.AreEqual(personData.Age, personDataSaved.Age);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, personDataSaved.Created.Date);
            Assert.AreEqual(personData.FirstName, personDataSaved.FirstName);
            Assert.IsTrue(personDataSaved.Id > 0);
            Assert.AreEqual(personData.LastName, personDataSaved.LastName);
            Assert.AreEqual(personData.ProfilePictureUrl, personDataSaved.ProfilePictureUrl);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, personDataSaved.Updated.Date);
        }

        [Test]
        public void InsertOrUpdatePerson_UpdatePerson()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personData = agent.InsertOrUpdatePerson(new PersonDataModel
            {
                Age = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            personData = new PersonDataModel
            {
                Age = 30,
                Created = personData.Created,
                FirstName = "JohnUpdated",
                Id = personData.Id,
                LastName = "SmithUpdated",
                ProfilePictureUrl = "testupdated.png",
                Updated = personData.Updated
            };

            // Act
            var personDataSaved = agent.InsertOrUpdatePerson(personData);

            // Assert
            Assert.IsNotNull(personDataSaved);
            Assert.AreEqual(personData.Age, personDataSaved.Age);
            Assert.AreEqual(personData.Created, personDataSaved.Created);
            Assert.AreEqual(personData.FirstName, personDataSaved.FirstName);
            Assert.AreEqual(personData.Id, personDataSaved.Id);
            Assert.AreEqual(personData.LastName, personDataSaved.LastName);
            Assert.AreEqual(personData.ProfilePictureUrl, personDataSaved.ProfilePictureUrl);
            Assert.IsTrue(personData.Updated < personDataSaved.Updated.Date);
        }

        [Test]
        public void SearchPeople_RecordsMatchInFirstNameOnly()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var recordCount = 10;
            var searchTerm = Guid.NewGuid().ToString();

            for(int i = 0; i < recordCount; i++)
            {
                agent.InsertOrUpdatePerson(new PersonDataModel
                {
                    Age = 30 + i,
                    FirstName = i + searchTerm + i,
                    LastName = i + "Smith" + i,
                    ProfilePictureUrl = i + "test.png",
                });
            }

            // Act
            var records = agent.SearchPeople(searchTerm);

            // Assert
            Assert.IsNotEmpty(records);
            Assert.AreEqual(recordCount, records.Count);
        }

        [Test]
        public void SearchPeople_RecordsMatchInLastNameOnly()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var recordCount = 10;
            var searchTerm = Guid.NewGuid().ToString();

            for (int i = 0; i < recordCount; i++)
            {
                agent.InsertOrUpdatePerson(new PersonDataModel
                {
                    Age = 30 + i,
                    FirstName = i + "John" + i,
                    LastName = i + searchTerm + i,
                    ProfilePictureUrl = i + "test.png",
                });
            }

            // Act
            var records = agent.SearchPeople(searchTerm);

            // Assert
            Assert.IsNotEmpty(records);
            Assert.AreEqual(recordCount, records.Count);
        }

        [Test]
        public void SearchPeople_RecordsMatchInBothFirstAndLastNames()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var recordCount = 10;
            var searchTerm = Guid.NewGuid().ToString();

            for (int i = 0; i < recordCount; i++)
            {
                agent.InsertOrUpdatePerson(new PersonDataModel
                {
                    Age = 30 + i,
                    FirstName = i + searchTerm + i,
                    LastName = i + "Smith" + i,
                    ProfilePictureUrl = i + "test.png",
                });
            }

            for (int i = 0; i < recordCount; i++)
            {
                agent.InsertOrUpdatePerson(new PersonDataModel
                {
                    Age = 30 + i,
                    FirstName = i + "John" + i,
                    LastName = i + searchTerm + i,
                    ProfilePictureUrl = i + "test.png",
                });
            }

            // Act
            var records = agent.SearchPeople(searchTerm);

            // Assert
            Assert.IsNotEmpty(records);
            Assert.AreEqual(recordCount*2, records.Count);
        }

        [Test]
        public void SearchPeople_NoRecordsMatch()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var recordCount = 10;
            var searchTerm = Guid.NewGuid().ToString();

            for (int i = 0; i < recordCount; i++)
            {
                agent.InsertOrUpdatePerson(new PersonDataModel
                {
                    Age = 30 + i,
                    FirstName = i + "John" + i,
                    LastName = i + "Smith" + i,
                    ProfilePictureUrl = i + "test.png",
                });
            }

            // Act
            var records = agent.SearchPeople(searchTerm);

            // Assert
            Assert.IsEmpty(records);
        }

        [Test]
        public void SelectAddressData_AddressesExist()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personData = agent.InsertOrUpdatePerson(new PersonDataModel
            {
                Age = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            var addressData = new AddressDataModel
            {
                Address1 = "123 Test Street",
                Address2 = "Suite 100",
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                City = "TestVille",
                Id = 0,
                PersonId = personData.Id,
                PostalCode = "88888",
                StateId = 1,
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            };

            addressData = agent.InsertOrUpdateAddress(addressData);

            // Act
            var addressList = agent.SelectAddressData(personData.Id);

            // Assert
            Assert.IsNotEmpty(addressList);
            Assert.IsTrue(addressList.Count == 1);
            var addressDataSaved = addressList.FirstOrDefault();
            Assert.IsNotNull(addressDataSaved);
            Assert.AreEqual(addressData.Address1, addressDataSaved.Address1);
            Assert.AreEqual(addressData.Address2, addressDataSaved.Address2);
            Assert.AreEqual(addressData.Created, addressDataSaved.Created);
            Assert.AreEqual(addressData.City, addressDataSaved.City);
            Assert.AreEqual(addressData.Id, addressDataSaved.Id);
            Assert.AreEqual(addressData.PersonId, addressDataSaved.PersonId);
            Assert.AreEqual(addressData.PostalCode, addressDataSaved.PostalCode);
            Assert.AreEqual(addressData.StateId, addressDataSaved.StateId);
            Assert.AreEqual(addressData.Updated, addressDataSaved.Updated);
        }

        [Test]
        public void SelectAddressData_AddressesDoNotExist()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personId = -1;

            // Act
            var addressList = agent.SelectAddressData(personId);

            // Assert
            Assert.IsEmpty(addressList);
        }

        [Test]
        public void SelectContactMethodData_ContactMethodsExist()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personData = agent.InsertOrUpdatePerson(new PersonDataModel
            {
                Age = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            var contactMethodData = new ContactMethodDataModel
            {
                ContactMethodTypeId = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                Id = 0,
                PersonId = personData.Id,
                Updated = DateTimeOffset.Now.AddDays(-10),
                Value = "801-555-1234"
            };

            contactMethodData = agent.InsertOrUpdateContactMethod(contactMethodData);

            // Act
            var contactMethodList = agent.SelectContactMethodData(personData.Id);

            // Assert
            Assert.IsNotEmpty(contactMethodList);
            Assert.IsTrue(contactMethodList.Count == 1);
            var contactMethodDataSaved = contactMethodList.FirstOrDefault();
            Assert.IsNotNull(contactMethodDataSaved);
            Assert.AreEqual(contactMethodData.ContactMethodTypeId, contactMethodDataSaved.ContactMethodTypeId);
            Assert.AreEqual(contactMethodData.Created, contactMethodDataSaved.Created);
            Assert.AreEqual(contactMethodData.Id, contactMethodDataSaved.Id);
            Assert.AreEqual(contactMethodData.PersonId, contactMethodDataSaved.PersonId);
            Assert.AreEqual(contactMethodData.Updated, contactMethodDataSaved.Updated);
            Assert.AreEqual(contactMethodData.Value, contactMethodDataSaved.Value);
        }

        [Test]
        public void SelectContactMethodData_ContactMethodsDoNotExist()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personId = -1;

            // Act
            var contactMethodList = agent.SelectContactMethodData(personId);

            // Assert
            Assert.IsEmpty(contactMethodList);
        }

        [Test]
        public void SelectInterestData_InterestsExist()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personData = agent.InsertOrUpdatePerson(new PersonDataModel
            {
                Age = 1,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 0,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            var interestData = new InterestDataModel
            {
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                Description = "Testing",
                Id = 0,
                PersonId = personData.Id,
                Updated = DateTimeOffset.Now.AddDays(-10),
            };

            interestData = agent.InsertOrUpdateInterest(interestData);

            // Act
            var interestList = agent.SelectInterestData(personData.Id);

            // Assert
            Assert.IsNotEmpty(interestList);
            Assert.IsTrue(interestList.Count == 1);
            var interestDataSaved = interestList.FirstOrDefault();
            Assert.IsNotNull(interestDataSaved);
            Assert.AreEqual(interestData.Created, interestDataSaved.Created);
            Assert.AreEqual(interestData.Description, interestDataSaved.Description);
            Assert.AreEqual(interestData.Id, interestDataSaved.Id);
            Assert.AreEqual(interestData.PersonId, interestDataSaved.PersonId);
            Assert.AreEqual(interestData.Updated, interestDataSaved.Updated);
        }

        [Test]
        public void SelectInterestData_InterestsDoNotExist()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personId = -1;

            // Act
            var interestList = agent.SelectInterestData(personId);

            // Assert
            Assert.IsEmpty(interestList);
        }

        [Test]
        public void SelectPersonData_PersonExists()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
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

            personData = agent.InsertOrUpdatePerson(personData);

            // Act
            var personDataSaved = agent.SelectPersonData(personData.Id);

            // Assert
            Assert.IsNotNull(personDataSaved);
            Assert.AreEqual(personData.Age, personDataSaved.Age);
            Assert.AreEqual(personData.Created, personDataSaved.Created);
            Assert.AreEqual(personData.FirstName, personDataSaved.FirstName);
            Assert.AreEqual(personData.Id, personDataSaved.Id);
            Assert.AreEqual(personData.LastName, personDataSaved.LastName);
            Assert.AreEqual(personData.ProfilePictureUrl, personDataSaved.ProfilePictureUrl);
            Assert.AreEqual(personData.Updated, personDataSaved.Updated);
        }

        [Test]
        public void SelectPersonData_PersonDoesNotExist()
        {
            // Arrange
            IPersonDataAgent agent = new PersonDataAgent(TEST_CONNECTION_STRING, true);
            var personId = -1;

            // Act
            var personData = agent.SelectPersonData(personId);

            // Assert
            Assert.IsNull(personData);
        }
    }
}

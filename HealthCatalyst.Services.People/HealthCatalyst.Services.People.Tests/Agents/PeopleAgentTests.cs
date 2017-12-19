using HealthCatalyst.Data.People.Interfaces;
using HealthCatalyst.Data.People.Models;
using HealthCatalyst.Services.People.Agents;
using HealthCatalyst.Services.People.Models;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HealthCatalyst.Services.People.Tests.Agents
{
    [TestFixture]
    public class PeopleAgentTests
    {
        [Test]
        public void GetPersonDetail_CallsPersonDataAgent()
        {
            // Arrange
            var personDataAgent = Substitute.For<IPersonDataAgent>();
            var peopleAgent = new PeopleAgent(personDataAgent, false);
            var personId = 100;
            personDataAgent.SelectPersonData(personId).ReturnsForAnyArgs(new PersonDataModel
            {
                Age = 30,
                Created = DateTimeOffset.UtcNow.AddDays(-30),
                FirstName = "John",
                Id = 100,
                LastName = "Smith",
                ProfilePictureUrl = "test.png",
                Updated = DateTimeOffset.UtcNow.AddDays(-10)
            });

            // Act
            peopleAgent.GetPersonDetail(personId);

            //Assert
            personDataAgent.Received(1).SelectPersonData(Arg.Is(personId));
            personDataAgent.Received(1).SelectAddressData(Arg.Is(personId));
            personDataAgent.Received(1).SelectContactMethodData(Arg.Is(personId));
            personDataAgent.Received(1).SelectInterestData(Arg.Is(personId));
        }

        [Test]
        public void SavePerson_CallsPersonDataAgent()
        {
            // Arrange
            var person = new PersonModel
            {
                Age = 30,
                FirstName = "First",
                Id = 1000,
                LastName = "Last",
                ProfilePictureUrl = "test.png"
            };

            var personDataAgent = Substitute.For<IPersonDataAgent>();
            var peopleAgent = new PeopleAgent(personDataAgent, false);

            // Act
            peopleAgent.SavePerson(person);

            //Assert
            personDataAgent.Received(1).InsertOrUpdatePerson(Arg.Is<PersonDataModel>(a =>
                a.Age == person.Age &&
                a.FirstName == person.FirstName &&
                a.Id == person.Id &&
                a.LastName == person.LastName &&
                a.ProfilePictureUrl == person.ProfilePictureUrl));
        }

        [Test]
        public void SaveAddress_CallsPersonDataAgent()
        {
            // Arrange
            var personId = 1000;

            var address = new AddressModel
            {
                Address1 = "Address 1",
                Address2 = "Address 2",
                City = "City",
                Id = 500,
                StateId = 45,
                PostalCode = "84095"
            };

            var personDataAgent = Substitute.For<IPersonDataAgent>();
            var peopleAgent = new PeopleAgent(personDataAgent, false);

            // Act
            peopleAgent.SaveAddress(personId, address);

            //Assert
            personDataAgent.Received(1).InsertOrUpdateAddress(Arg.Is<AddressDataModel>(a =>
                a.Address1 == address.Address1 &&
                a.Address2 == address.Address2 &&
                a.City == address.City &&
                a.Id == address.Id &&
                a.PersonId == personId &&
                a.StateId == address.StateId &&
                a.PostalCode == address.PostalCode));
        }

        [Test]
        public void SaveContactMethod_CallsPersonDataAgent()
        {
            // Arrange
            var personId = 1000;

            var contactMethod = new ContactMethodModel
            {
                Id = 100,
                ContactMethodTypeId = 1,
                Value = "80155555555"
            };

            var personDataAgent = Substitute.For<IPersonDataAgent>();
            var peopleAgent = new PeopleAgent(personDataAgent, false);

            // Act
            peopleAgent.SaveContactMethod(personId, contactMethod);

            //Assert
            personDataAgent.Received(1).InsertOrUpdateContactMethod(Arg.Is<ContactMethodDataModel>(a =>
                a.Id == contactMethod.Id &&
                a.ContactMethodTypeId == contactMethod.ContactMethodTypeId &&
                a.PersonId == personId &&
                a.Value == contactMethod.Value));
        }

        [Test]
        public void SaveInterest_CallsPersonDataAgent()
        {
            // Arrange
            var personId = 1000;

            var interest = new InterestModel
            {
                Id = 200,
                Description = "Hiking"
            };

            var personDataAgent = Substitute.For<IPersonDataAgent>();
            var peopleAgent = new PeopleAgent(personDataAgent, false);

            // Act
            peopleAgent.SaveInterest(personId, interest);

            //Assert
            personDataAgent.Received(1).InsertOrUpdateInterest(Arg.Is<InterestDataModel>(a =>
                a.Id == interest.Id &&
                a.Description == interest.Description &&
                a.PersonId == personId));
        }

        [Test]
        public void SearchPeople_CallsPersonDataAgent()
        {
            // Arrange
            var searchTerm = "abc";
            var personDataAgent = Substitute.For<IPersonDataAgent>();
            var peopleAgent = new PeopleAgent(personDataAgent, false);
            personDataAgent.SearchPeople(searchTerm).ReturnsForAnyArgs(new List<PersonDataModel>()
            {
                new PersonDataModel
                {
                    Age = 30,
                    Created = DateTimeOffset.UtcNow.AddDays(-30),
                    FirstName = "John",
                    Id = 100,
                    LastName = "Smith",
                    ProfilePictureUrl = "test.png",
                    Updated = DateTimeOffset.UtcNow.AddDays(-10)
                }
            });

            // Act
            peopleAgent.SearchPeople(searchTerm);

            //Assert
            personDataAgent.Received(1).SearchPeople(Arg.Is(searchTerm));
        }
    }
}

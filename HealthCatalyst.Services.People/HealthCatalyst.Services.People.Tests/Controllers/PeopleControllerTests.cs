using HealthCatalyst.Services.People.Controllers;
using HealthCatalyst.Services.People.Interfaces;
using HealthCatalyst.Services.People.Models;
using NSubstitute;
using NUnit.Framework;

namespace HealthCatalyst.Services.People.Tests.Controllers
{
    [TestFixture]
    public class PeopleControllerTests
    {
        [Test]
        public void GetPersonDetail_CallsPeopleAgent()
        {
            // Arrange
            var personId = 1000;
            var peopleAgent = Substitute.For<IPeopleAgent>();
            var controller = new PeopleController(peopleAgent);

            // Act
            controller.GetPersonDetail(personId);

            //Assert
            peopleAgent.Received(1).GetPersonDetail(Arg.Is(personId));
        }

        [Test]
        public void SavePerson_CallsPeopleAgent()
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

            var peopleAgent = Substitute.For<IPeopleAgent>();
            var controller = new PeopleController(peopleAgent);

            // Act
            controller.SavePerson(person);

            //Assert
            peopleAgent.Received(1).SavePerson(Arg.Is(person));
        }

        [Test]
        public void SaveAddress_CallsPeopleAgent()
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

            var peopleAgent = Substitute.For<IPeopleAgent>();
            var controller = new PeopleController(peopleAgent);

            // Act
            controller.SaveAddress(personId, address);

            //Assert
            peopleAgent.Received(1).SaveAddress(Arg.Is(personId), Arg.Is(address));
        }

        [Test]
        public void SaveContactMethod_CallsPeopleAgent()
        {
            // Arrange
            var personId = 1000;

            var contactMethod = new ContactMethodModel
            {
                Id = 100,
                ContactMethodTypeId = 1,
                Value = "80155555555"
            };

            var peopleAgent = Substitute.For<IPeopleAgent>();
            var controller = new PeopleController(peopleAgent);

            // Act
            controller.SaveContactMethod(personId, contactMethod);

            //Assert
            peopleAgent.Received(1).SaveContactMethod(Arg.Is(personId), Arg.Is(contactMethod));
        }

        [Test]
        public void SaveInterest_CallsPeopleAgent()
        {
            // Arrange
            var personId = 1000;

            var interest = new InterestModel
            {
                Id = 200,
                Description = "Hiking"
            };

            var peopleAgent = Substitute.For<IPeopleAgent>();
            var controller = new PeopleController(peopleAgent);

            // Act
            controller.SaveInterest(personId, interest);

            //Assert
            peopleAgent.Received(1).SaveInterest(Arg.Is(personId), Arg.Is(interest));
        }

        [Test]
        public void SearchPeople_CallsPeopleAgent()
        {
            // Arrange
            var searchTerm = "abc";
            var peopleAgent = Substitute.For<IPeopleAgent>();
            var controller = new PeopleController(peopleAgent);

            // Act
            controller.SearchPeople(searchTerm);

            //Assert
            peopleAgent.Received(1).SearchPeople(Arg.Is(searchTerm));
        }
    }
}

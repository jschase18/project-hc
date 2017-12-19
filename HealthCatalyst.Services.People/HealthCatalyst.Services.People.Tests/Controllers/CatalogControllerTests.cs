using HealthCatalyst.Services.People.Controllers;
using HealthCatalyst.Services.People.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace HealthCatalyst.Services.People.Tests.Controllers
{
    [TestFixture]
    public class CatalogControllerTests
    {
        [Test]
        public void GetContactMethodTypes_CallsCatalogAgent()
        {
            // Arrange
            var catalogAgent = Substitute.For<ICatalogAgent>();
            var controller = new CatalogController(catalogAgent);

            // Act
            controller.GetStates();

            //Assert
            catalogAgent.Received(1).GetStates();
        }

        [Test]
        public void GetStates_CallsCatalogAgent()
        {
            // Arrange
            var catalogAgent = Substitute.For<ICatalogAgent>();
            var controller = new CatalogController(catalogAgent);

            // Act
            controller.GetContactMethodTypes();

            //Assert
            catalogAgent.Received(1).GetContactMethodTypes();
        }
    }
}

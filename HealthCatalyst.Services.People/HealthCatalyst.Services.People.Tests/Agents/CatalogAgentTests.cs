using HealthCatalyst.Data.People.Interfaces;
using HealthCatalyst.Data.People.Models;
using HealthCatalyst.Services.People.Agents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace HealthCatalyst.Services.People.Tests.Agents
{
    [TestFixture]
    public class CatalogAgentTests
    {
        [Test]
        public void GetContactMethodTypes_CallsCatalogDataAgent()
        {
            // Arrange
            var catalogDataAgent = Substitute.For<ICatalogDataAgent>();
            var catalogAgent = new CatalogAgent(catalogDataAgent);
            catalogDataAgent.SelectContactMethodTypes().ReturnsForAnyArgs(new List<CatalogDataModel>()
            {
                new CatalogDataModel
                {
                    Id = 1,
                    Name = "Phone"
                },
                new CatalogDataModel
                {
                    Id = 1,
                    Name = "Email"
                },
            });

            // Act
            catalogAgent.GetContactMethodTypes();

            //Assert
            catalogDataAgent.Received(1).SelectContactMethodTypes();
        }

        [Test]
        public void GetStates_CallsCatalogDataAgent()
        {
            // Arrange
            var catalogDataAgent = Substitute.For<ICatalogDataAgent>();
            var catalogAgent = new CatalogAgent(catalogDataAgent);
            catalogDataAgent.SelectStates().ReturnsForAnyArgs(new List<CatalogDataModel>()
            {
                new CatalogDataModel
                {
                    Id = 1,
                    Name = "Alabama"
                },
                new CatalogDataModel
                {
                    Id = 1,
                    Name = "Alaska"
                },
                new CatalogDataModel
                {
                    Id = 1,
                    Name = "Arizona"
                }
            });

            // Act
            catalogAgent.GetStates();

            //Assert
            catalogDataAgent.Received(1).SelectStates();
        }
    }
}

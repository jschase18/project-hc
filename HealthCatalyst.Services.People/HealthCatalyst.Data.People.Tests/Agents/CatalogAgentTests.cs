using HealthCatalyst.Data.People.Agents;
using HealthCatalyst.Data.People.Interfaces;
using NUnit.Framework;
using System.Linq;

namespace HealthCatalyst.Data.People.Tests.Agents
{
    [TestFixture]
    public class CatalogAgentTests
    {
        private const string TEST_CONNECTION_STRING = "Data Source=localhost;Initial Catalog=PeopleTests_DAD891B8F4B449F780625720F14D7A91;Trusted_Connection=True;MultipleActiveResultSets=True;";

        [Test]
        public void SelectContactMethodTypes_ReturnsValidData()
        {
            // Arrange
            ICatalogDataAgent agent = new CatalogDataAgent(TEST_CONNECTION_STRING, true);

            // Act
            var contactMethodTypeList = agent.SelectContactMethodTypes();

            // Assert
            Assert.IsTrue(contactMethodTypeList.Any(x => x.Id == 1));
            Assert.IsTrue(contactMethodTypeList.Any(x => x.Id == 2));
        }

        [Test]
        public void SelectStates_ReturnsValidData()
        {
            // Arrange
            ICatalogDataAgent agent = new CatalogDataAgent(TEST_CONNECTION_STRING, true);

            // Act
            var stateList = agent.SelectStates();

            // Assert
            for(int i = 1; i <= 50; i++)
            {
                Assert.IsTrue(stateList.Any(x => x.Id == i));
            }
        }
    }
}

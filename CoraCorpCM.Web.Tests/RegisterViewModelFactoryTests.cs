using CoraCorpCM.Application.Countries.Queries;
using CoraCorpCM.Web.Services.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class RegisterViewModelFactoryTests
    {
        RegisterViewModelFactory factory;

        Mock<IGetCountryListQuery> mockCountryListQuery;

        CountryModel country;

        [TestInitialize]
        public void SetUp()
        {
            country = new CountryModel
            {
                Id = 1,
                Name = "country"
            };

            mockCountryListQuery = new Mock<IGetCountryListQuery>();
            mockCountryListQuery.Setup(q => q.Execute())
                .Returns(new List<CountryModel> { country });

            factory = new RegisterViewModelFactory(mockCountryListQuery.Object);
        }

        [TestMethod]
        public void Create_SetsCountries()
        {
            // Arrange
            var expectedValue = country.Id.ToString();
            var expectedText = country.Name;

            // Act
            var result = factory.Create();

            // Assert
            var actualValue = result.Countries.Single().Value;
            var actualText = result.Countries.Single().Text;
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }
    }
}

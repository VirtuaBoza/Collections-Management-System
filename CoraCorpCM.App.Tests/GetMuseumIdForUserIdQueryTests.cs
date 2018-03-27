using CoraCorpCM.App.Museums.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoraCorpCM.App.Tests
{
    [TestClass]
    public class GetMuseumIdForUserIdQueryTests
    {
        GetMuseumIdForUserIdQuery query;

        [TestInitialize]
        public void SetUp()
        {
            var mockUserManager = AppMockHelper.GetMockUserManager();
            query = new GetMuseumIdForUserIdQuery(mockUserManager.Object);
        }
    }
}

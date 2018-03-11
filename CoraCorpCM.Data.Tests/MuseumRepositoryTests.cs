using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using CoraCorpCM.Domain.Models;
using System.Linq;

namespace CoraCorpCM.Data.Tests
{
    [TestClass]
    public class MuseumRepositoryTests
    {
        [TestMethod]
        public void Insert_WithNewMuseum_WritesToTheDatabase()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new MuseumRepository(context);
                    repo.Insert(new Museum { Name = "Test Museum", ShortName = "TM" });
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new ApplicationDbContext(options))
                {
                    Assert.AreEqual(1, context.Museums.Count());
                    Assert.AreEqual("Test Museum", context.Museums.Single().Name);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

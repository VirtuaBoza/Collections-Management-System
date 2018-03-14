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
            // Arrange
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    var repo = new MuseumRepository(context);

                    // Act
                    repo.Insert(new Museum { Name = "Test Museum", ShortName = "TM" });
                }

                using (var context = new ApplicationDbContext(options))
                {
                    // Assert
                    Assert.AreEqual(1, context.Museums.Count());
                    Assert.AreEqual("Test Museum", context.Museums.Single().Name);
                }
            }
            finally
            {
                // Cleanup
                connection.Close();
            }
        }

        [TestMethod]
        public void Insert_WithNewPiece_WritesToTheDatabase()
        {
            // Arrange
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    var repo = new MuseumRepository(context);
                    var museum = new Museum { Name = "Test Museum", ShortName = "TM" };
                    context.Add(museum);
                    context.SaveChanges();

                    // Act
                    repo.Insert(new Piece { Title = "Test Piece", Museum = museum });
                }

                using (var context = new ApplicationDbContext(options))
                {
                    // Assert
                    Assert.AreEqual(1, context.Pieces.Count());
                    Assert.AreEqual(1, context.Pieces.Single().RecordNumber);
                }
            }
            finally
            {
                // Cleanup
                connection.Close();
            }
        }

        [TestMethod]
        public void GetFirstEntity_WithMuseum_RetrievesFirstMuseumInTheDatabase()
        {
            // Arrange
            var expectedMuseum = new Museum { Name = "Test Museum1", ShortName = "TM1" };

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    context.Add(expectedMuseum);
                    context.Add(new Museum { Name = "Test Museum2", ShortName = "TM2" });
                    context.SaveChanges();
                }

                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new MuseumRepository(context);

                    // Act
                    var actualMuseum = repo.GetFirstEntity<Museum>();

                    // Assert
                    Assert.AreEqual(expectedMuseum.Name, actualMuseum.Name);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [TestMethod]
        public void GetEntity_WithMuseum_RetrievesCorrectMuseumInTheDatabase()
        {
            // Arrange
            var expectedMuseum = new Museum { Name = "Test Museum1", ShortName = "TM1" };

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    context.Add(new Museum { Name = "Test Museum2", ShortName = "TM2" });
                    expectedMuseum = context.Add(expectedMuseum).Entity;
                    context.SaveChanges();
                }

                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new MuseumRepository(context);

                    // Act
                    var actualMuseum = repo.GetEntity<Museum>(expectedMuseum.Id);

                    // Assert
                    Assert.AreEqual(expectedMuseum.Name, actualMuseum.Name);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [TestMethod]
        public void GetEntities_WithPiece_RetrievesPiecesFromTheDatabase()
        {
            // Arrange
            var expectedMuseum = new Museum { Name = "Test Museum1", ShortName = "TM1" };

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    expectedMuseum = context.Add(expectedMuseum).Entity;
                    var evilMuseum = context.Add(new Museum { Name = "Test Museum2", ShortName = "TM2" }).Entity;
                    context.Add(new Piece { Title = "Title1", Museum = expectedMuseum });
                    context.Add(new Piece { Title = "Title2", Museum = expectedMuseum });
                    context.Add(new Piece { Title = "Title3", Museum = evilMuseum });
                    context.SaveChanges();
                }

                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new MuseumRepository(context);

                    // Act
                    var actualPieces = repo.GetEntities<Piece>(expectedMuseum);

                    // Assert
                    Assert.AreEqual(2, actualPieces.ToList().Count);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [TestMethod]
        public void GetEntitiesAsNoTracking_WithPiece_RetrievesUntrackedPiecesFromTheDatabase()
        {
            // Arrange
            var museum = new Museum { Name = "Test Museum1", ShortName = "TM1" };

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    museum = context.Add(museum).Entity;
                    context.Add(new Piece { Title = "Title1", Museum = museum });
                    context.Add(new Piece { Title = "Title2", Museum = museum });
                    context.Add(new Piece { Title = "Title3", Museum = museum });
                    context.SaveChanges();
                }

                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new MuseumRepository(context);

                    // Act
                    var pieces = repo.GetEntitiesAsNoTracking<Piece>(museum).ToList();
                    pieces[0].Title = "Title4";
                    context.SaveChanges();

                    // Assert
                    Assert.AreEqual("Title1", context.Pieces.First().Title);

                    // Double check
                    var piecesTracked = repo.GetEntities<Piece>(museum).ToList();
                    piecesTracked[0].Title = "Title4";
                    context.SaveChanges();
                    Assert.AreEqual("Title4", context.Pieces.First().Title);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [TestMethod]
        public void GetEntitiesAsNoTracking_WithCountry_RetrievesUntrackedCountriesFromTheDatabase()
        {
            // Arrange
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    context.Add(new Country { Name = "USA", Code = "USA" });
                    context.SaveChanges();
                }

                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new MuseumRepository(context);

                    // Act
                    var countries = repo.GetEntitiesAsNoTracking<Country>().ToList();
                    countries[0].Name = "America";
                    context.SaveChanges();

                    // Assert
                    Assert.AreEqual("USA", context.Countries.First().Name);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [TestMethod]
        public void EntityExists_WithExistingMuseum_ReturnsTrue()
        {
            // Arrange
            var museum = new Museum { Name = "Test Museum", ShortName = "TM" };

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    museum = context.Add(museum).Entity;
                    context.SaveChanges();
                }

                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new MuseumRepository(context);

                    // Act
                    var result = repo.EntityExists<Museum>(museum.Id);

                    // Assert
                    Assert.IsTrue(result);
                }
            }
            finally
            {
                // Cleanup
                connection.Close();
            }
        }

        [TestMethod]
        public void Delete_Museum_RemovesMuseumFromDatabase()
        {
            // Arrange
            var museum = new Museum { Name = "Test Museum", ShortName = "TM" };

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    museum = context.Add(museum).Entity;
                    context.SaveChanges();
                    Assert.IsTrue(context.Museums.Any());
                }

                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new MuseumRepository(context);

                    // Act
                    repo.Delete(museum);

                    // Assert
                    Assert.IsFalse(context.Museums.Any());
                }
            }
            finally
            {
                // Cleanup
                connection.Close();
            }
        }

        [TestMethod]
        public void Delete_MuseumById_RemovesMuseumFromDatabase()
        {
            // Arrange
            var museum = new Museum { Name = "Test Museum", ShortName = "TM" };

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    museum = context.Add(museum).Entity;
                    context.SaveChanges();
                    Assert.IsTrue(context.Museums.Any());
                }

                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new MuseumRepository(context);

                    // Act
                    repo.Delete<Museum>(museum.Id);

                    // Assert
                    Assert.IsFalse(context.Museums.Any());
                }
            }
            finally
            {
                // Cleanup
                connection.Close();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Moq;
using VetClinic.DAL;
using VetClinic.DAL.Entities;
using VetClinic.DAL.Repository.Realizations;

namespace Tests
{
    public class UnitTest1
    {
       /* [Fact]
        public void GetById_ExistingId_ReturnsAnimal()
        {
            // Arrange
            string animalId = "1";
            var animal = new Animal()
            {
                Id = animalId,
                OwnerId = "2",
                Name = "Catalina",
                AnimalKind = Animal.Kind.Cat,
                AnimalSex = Animal.Sex.Female,
                Age = 2,
                Description = "-"
            };

            var animals = new List<Animal> { animal }.AsQueryable();

            var options = new DbContextOptionsBuilder<AppDatabaseContext>()
            .UseInMemoryDatabase(databaseName: "test_database")
            .Options;

            var mockDbSet = new Mock<DbSet<Animal>>();
            mockDbSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(animals.Provider);
            mockDbSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(animals.Expression);
            mockDbSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(animals.ElementType);
            mockDbSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(animals.GetEnumerator());


            var mockDbContext = new Mock<AppDatabaseContext>(options);
            mockDbContext.Setup(x => x.Set<Animal>()).Returns(mockDbSet.Object);

            // Act
            var animalRepository = new AnimalRepository(mockDbContext.Object);
            var result = animalRepository.GetByIdAsync(animalId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(animalId, result.Result.Id);
            Assert.Equal("Catalina", result.Result.Name);
        }*/
    }
}
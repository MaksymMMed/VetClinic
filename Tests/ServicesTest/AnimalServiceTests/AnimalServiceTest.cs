using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BLL.DTO.Request;
using VetClinic.BLL.Configs;
using VetClinic.BLL.Services.Realizations;
using VetClinic.DAL.Entities;
using VetClinic.DAL.Exeptions;
using VetClinic.DAL.Repository.Interfaces;
using VetClinic.DAL.UnitOfWork;

namespace Tests.ServicesTest.AnimalServiceTests
{
    public class AnimalServiceTest
    {
        public IMapper GetMapper()
        {
            var MappingProfile = new MapperProfile();
            var Configuration = new MapperConfiguration(cfg => cfg.AddProfile(MappingProfile));
            return new Mapper(Configuration);
        }

        //

        [Fact]
        public async void GetAnimalById_ExistingId_ReturnsAnimalById()
        {
            // Arrange
            string ProductId = "1";

            var MockAnimalRepository = MockIAnimalRepository.GetMock();
            var MockMapper = GetMapper();
            var MockUnitOfWork = new Mock<IUnitOfWork>();
            
            MockUnitOfWork.Setup(x=>x.AnimalRepository).Returns(MockAnimalRepository.Object);

            var AnimalService = new AnimalService(MockUnitOfWork.Object,MockMapper) ;

            // Act
            var Result = await AnimalService.GetEntityByIdAsync(ProductId);

            // Assert
            Assert.Equal(ProductId, Result.Id);
            Assert.Equal("Cat", Result.AnimalKind);
            Assert.Equal("Female", Result.AnimalSex);
        }

        //

        [Fact]
        public async void GetAnimalById_WrongId_ThrowNotFoundException()
        {
            // Arrange
            string ProductId = "2"; 

            var MockAnimalRepository = MockIAnimalRepository.GetMock();
            var MockMapper = GetMapper();
            var MockUnitOfWork = new Mock<IUnitOfWork>();

            MockUnitOfWork.Setup(x => x.AnimalRepository).Returns(MockAnimalRepository.Object);

            var AnimalService = new AnimalService(MockUnitOfWork.Object, MockMapper);

            // Act
            var Result = AnimalService.GetEntityByIdAsync(ProductId);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(()=> Result);
        }

        //

        [Fact]
        public async void UpdateAnimal_PutValidAnimal_Success()
        {
            // Arrange
            var MockAnimalRepository = MockIAnimalRepository.GetMock();
            var MockMapper = GetMapper();
            var MockUnitOfWork = new Mock<IUnitOfWork>();

            MockUnitOfWork.Setup(x => x.AnimalRepository).Returns(MockAnimalRepository.Object);

            var AnimalService = new AnimalService(MockUnitOfWork.Object, MockMapper);

            var AnimalRequest = new AnimalRequest
            {
                Id = "1",
                OwnerId = "3",
                Name = "Catar",
                AnimalKind = "Dog",
                AnimalSex = "Male",
                Age = 2,
                Description = "-"
            };

            // Act
            await AnimalService.UpdateEntity(AnimalRequest);
            var Result = await MockAnimalRepository.Object.GetByIdAsync("1");

            // Assert
            Assert.NotNull(Result);
            Assert.Equal("1", Result.Id);
            Assert.Equal("Catar", Result.Name);
            Assert.Equal("Dog", Result.AnimalKind.ToString());
            Assert.Equal("Male", Result.AnimalSex.ToString());

        }
    }
}

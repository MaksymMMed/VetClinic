using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BLL.DTO.Request;
using VetClinic.DAL.Entities;
using VetClinic.DAL.Exeptions;
using VetClinic.DAL.Repository.Interfaces;

namespace Tests.ServicesTest.AnimalServiceTests
{
    internal class MockIAnimalRepository
    {
        public static Mock<IAnimalRepository> GetMock()
        {
            var mock = new Mock<IAnimalRepository>();

            var Animals = new List<Animal>()
            {
                new Animal()
                {
                Id = "1",
                OwnerId = "2",
                Name = "Catalina",
                AnimalKind = Animal.Kind.Cat,
                AnimalSex = Animal.Sex.Female,
                Age = 2,
                Description = "-"
                },
                new Animal()
                {
                Id = "3",
                OwnerId = "2",
                Name = "Catar",
                AnimalKind = Animal.Kind.Lizard,
                AnimalSex = Animal.Sex.Male,
                Age = 3,
                Description = "-"
                }
            };


            mock.Setup(m => m.GetAllAsync()).ReturnsAsync(() => Animals);

            mock.Setup(m => m.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync((string id) =>
                {
                    var item = Animals.FirstOrDefault(o => o.Id == id);
                    if (item is null)
                    {
                        throw new NotFoundException($"Entity with id {id} not found");
                    }
                    return item;
                });

            mock.Setup(m => m.InsertAsync(It.IsAny<Animal>()))
                .Callback((Animal animal) =>
                {
                    Animals.Add(animal);
                });

            mock.Setup(m => m.UpdateAsync(It.IsAny<Animal>()))
               .Callback((Animal animal) => 
               {
                   int Index = Animals.IndexOf(Animals.Where(x => x.Id == animal.Id).First());
                   Animals[Index] = animal;
               });

            mock.Setup(m => m.DeleteAsync(It.IsAny<string>()))
               .Callback((string id) => 
               {
                    var Item = Animals.Where(x => x.Id == id).FirstOrDefault();
                   if (Item is null)
                   {
                        throw new NotFoundException($"Entity with id {id} not found");
                   }
                   Animals.Remove(Item!);
               });

            return mock;
        }
    }
}

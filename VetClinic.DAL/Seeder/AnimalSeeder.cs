using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;

namespace VetClinic.DAL.Seeder
{
    internal class AnimalSeeder : ISeeder<Animal>
    {
        public List<Animal> Seed() => AnimalsList;

        List<Animal> AnimalsList = new()
        {
            new Animal
            {
                Id  = Guid.NewGuid().ToString(),
                OwnerId = "2",
                Name = "Catalina",
                AnimalKind = Animal.Kind.Cat,
                AnimalSex = Animal.Sex.Female,
                Age = 2,
                Description = "-"
            }
        };
    }
}

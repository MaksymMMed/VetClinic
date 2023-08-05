using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;
using VetClinic.DAL.EntitySearchConditions;
using VetClinic.DAL.Exeptions;
using VetClinic.DAL.Repository.Interfaces;

namespace VetClinic.DAL.Repository.Realizations
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(AppDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<Animal> GetByIdAsync(string id)
        {
            var item = await table
                .Where(x => x.Id == id)
                .Include(x => x.Owner)
                .Include(x => x.Appointments).ThenInclude(x => x.Doctor)
                .FirstOrDefaultAsync();

            if (item == null)
            {
                throw new NotFoundException($"Animal with id {id} not found");
            }

            return item!;
        }

        public async Task<List<Animal>> GetEntitiesByConditionAsync(AnimalCondition condition)
        {
            IQueryable<Animal> items = table.Include(x => x.Owner);

            SearchByAnimalName(ref items, condition.AnimalName?.ToLower());
            SearchByAnimalAge(ref items, condition.MinAnimalAge, condition.MinAnimalAge);
            SearchByAnimalKind(ref items, condition.AnimalKinds);
            SearchByAnimalSex(ref items, condition.AnimalSex);
            
            return await items.ToListAsync();
        }

        void SearchByAnimalName(ref IQueryable<Animal> animals,string? animalName)
        {
            if (animalName.IsNullOrEmpty())
            {
                return;
            }
            animals = animals.Where(x => x.Name.ToLower().Contains(animalName!));
        }

        void SearchByAnimalAge(ref IQueryable<Animal> animals, int? MaxAge, int? MinAge)
        {
            /*if (MaxAge == null && MinAge == null)
            {
                return;
            }*/
            if (MaxAge != null)
            {
                animals = animals.Where(x => x.Age <= MaxAge);
            }
            if (MinAge != null)
            {
                animals = animals.Where(x => x.Age >= MinAge);
            }
        }

        void SearchByAnimalKind(ref IQueryable<Animal> animals, int[]? kinds)
        {
            if (kinds == null)
            {
                return;
            }
            animals = animals.Where(x => kinds.Contains((int)x.AnimalKind));
        }
        void SearchByAnimalSex(ref IQueryable<Animal> animals, int? sex)
        {
            if (sex == null)
            {
                return;
            }
            animals = animals.Where(x => (int)x.AnimalSex == sex);
        }
    }
}

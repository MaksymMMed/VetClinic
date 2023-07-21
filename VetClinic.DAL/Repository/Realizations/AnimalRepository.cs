using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;
using VetClinic.DAL.Exeptions;
using VetClinic.DAL.Repository.Interfaces;

namespace VetClinic.DAL.Repository.Realizations
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(AppDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override Task<Animal> GetByIdAsync(string id)
        {
            var item = table.Where(x=>x.Id == id).Include(x=>x.Owner).FirstOrDefaultAsync();

            if (item == null)
            {
                throw new NotFoundExeption($"Animal with id {id} not found");
            }

            return item!;
        }
    }
}

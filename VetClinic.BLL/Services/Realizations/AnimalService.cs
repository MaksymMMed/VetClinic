using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BLL.DTO.Request;
using VetClinic.BLL.DTO.Response;
using VetClinic.BLL.Services.Interfaces;
using VetClinic.DAL.Entities;
using VetClinic.DAL.EntitySearchConditions;
using VetClinic.DAL.UnitOfWork;


namespace VetClinic.BLL.Services.Realizations
{
    public class AnimalService : IAnimalService
    {
        private readonly IMapper Mapper;
        private readonly IUnitOfWork Unit;

        public AnimalService(IUnitOfWork unit, IMapper mapper)
        {
            Unit = unit;
            Mapper = mapper;
        }

        public async Task AddEntityAsync(AnimalRequest request)
        {
            var Item = Mapper.Map<Animal>(request);
            await Unit.AnimalRepository.InsertAsync(Item);
            await Unit.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(string id)
        {
            await Unit.AnimalRepository.DeleteAsync(id);
            await Unit.SaveChangesAsync();
        }

        public async Task<List<AnimalResponse>> GetAllEntitiesAsync()
        {
            List<Animal> Item = await Unit.AnimalRepository.GetAllAsync();
            return Mapper.Map<List<Animal>, List<AnimalResponse>>(Item);
        }

        public async Task<List<AnimalResponse>> GetEntitiesByConditionAsync(AnimalCondition condition)
        {
            List<Animal> Item = await Unit.AnimalRepository.GetEntitiesByConditionAsync(condition);
            return Mapper.Map<List<Animal>, List<AnimalResponse>>(Item);
        }

        public async Task<AnimalResponse> GetEntityByIdAsync(string id)
        {
            var Item = await Unit.AnimalRepository.GetByIdAsync(id);
            var MappedItem = Mapper.Map<AnimalResponse>(Item);
            return MappedItem;
        }

        public async Task UpdateEntity(AnimalRequest request)
        {
            var Item = Mapper.Map<Animal>(request);
            await Unit.AnimalRepository.UpdateAsync(Item);
            await Unit.SaveChangesAsync();
        }
    }
}

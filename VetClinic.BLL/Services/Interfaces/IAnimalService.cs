using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BLL.DTO.Request;
using VetClinic.BLL.DTO.Response;
using VetClinic.DAL.EntitySearchConditions;

namespace VetClinic.BLL.Services.Interfaces
{
    public interface IAnimalService
    {
        Task AddEntityAsync(AnimalRequest request);
        Task UpdateEntity(AnimalRequest request);
        Task DeleteEntityAsync(string id);
        Task<AnimalResponse> GetEntityByIdAsync(string id);
        Task<List<AnimalResponse>> GetAllEntitiesAsync();
        Task<List<AnimalResponse>> GetEntitiesByConditionAsync(AnimalCondition condition);
    }
}

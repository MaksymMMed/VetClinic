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
    public interface IAppointmentService
    {
        Task AddEntityAsync(AppointmentRequest request);
        Task UpdateEntity(AppointmentRequest request);
        Task DeleteEntityAsync(string id);
        Task<AppointmentResponse> GetEntityByIdAsync(string id);
        Task<List<AppointmentResponse>> GetAllEntitiesAsync();
        Task<List<AppointmentResponse>> GetEntitiesByConditionAsync(AppointmentCondition condition);
    }
}

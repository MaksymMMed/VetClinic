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
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork Unit;
        private readonly IMapper Mapper;
        public AppointmentService(IUnitOfWork unit, IMapper mapper)
        {
            Unit = unit;
            Mapper = mapper;
        }

        

        public async Task AddEntityAsync(AppointmentRequest request)
        {
            var Item = Mapper.Map<Appointment>(request);
            await Unit.AppointmentRepository.InsertAsync(Item);
            await Unit.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(string id)
        {
            await Unit.AppointmentRepository.DeleteAsync(id);
            await Unit.SaveChangesAsync();
        }

        public async Task<List<AppointmentResponse>> GetAllEntitiesAsync()
        {
            List<Appointment> Item = await Unit.AppointmentRepository.GetAllAsync();
            return Mapper.Map<List<Appointment>, List<AppointmentResponse>>(Item);
        }

        public async Task<List<AppointmentResponse>> GetEntitiesByConditionAsync(AppointmentCondition condition)
        {
            List<Appointment> Item = await Unit.AppointmentRepository.GetEntitiesByConditionAsync(condition);
            return Mapper.Map<List<Appointment>, List<AppointmentResponse>>(Item);
        }

        public async Task<AppointmentResponse> GetEntityByIdAsync(string id)
        {
            var Item = await Unit.AppointmentRepository.GetByIdAsync(id);
            var MappedItem = Mapper.Map<AppointmentResponse>(Item);
            return MappedItem;
        }

        public async Task UpdateEntity(AppointmentRequest request)
        {
            var Item = Mapper.Map<Appointment>(request);
            await Unit.AppointmentRepository.UpdateAsync(Item);
            await Unit.SaveChangesAsync();
        }
    }
}

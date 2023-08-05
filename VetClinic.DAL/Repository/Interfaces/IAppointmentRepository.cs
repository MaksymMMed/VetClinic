using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;
using VetClinic.DAL.EntitySearchConditions;

namespace VetClinic.DAL.Repository.Interfaces
{
    public interface IAppointmentRepository:IRepository<Appointment>
    {
        public Task<List<Appointment>> GetEntitiesByConditionAsync(AppointmentCondition condition);
    }
}

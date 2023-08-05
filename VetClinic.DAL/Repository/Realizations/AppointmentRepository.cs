using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;
using VetClinic.DAL.EntitySearchConditions;
using VetClinic.DAL.Exeptions;
using VetClinic.DAL.Repository.Interfaces;

namespace VetClinic.DAL.Repository.Realizations
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override Task<Appointment> GetByIdAsync(string id)
        {
            var item = table.Where(x => x.Id == id).Include(x=>x.Doctor).Include(x=>x.Animal).FirstOrDefaultAsync();

            if (item == null)
            {
                throw new NotFoundException($"Appointment with id {id} not found");
            }

            return item!;
        }

        public async Task<List<Appointment>> GetEntitiesByConditionAsync(AppointmentCondition condition)
        {
            IQueryable<Appointment> appointments = table.Include(x=>x.Animal).Include(x=>x.Doctor);


            SearchByDate(ref appointments,condition.StartDate,condition.EndDate);
            SearchByComplete(ref appointments, condition.IsOver);

            return await appointments.ToListAsync();
        }

        void SearchByDate(ref IQueryable<Appointment> appointments, string? start, string? end)
        {


            if (start != null)
            {
                DateTime startTime = DateTime.ParseExact(start, "dd-MM-yyyy-HH-mm-ss", CultureInfo.InvariantCulture);
                appointments = appointments.Where(x => x.StartTime >= startTime);
            }
            if (end != null)
            {
                DateTime endTime = DateTime.ParseExact(end, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                appointments = appointments.Where(x => x.EndTime <= endTime);
            }
        }

        void SearchByComplete(ref IQueryable<Appointment> appointments, bool? isComplete)
        {
            if (isComplete != null)
            {
                appointments = appointments.Where(x=>x.IsOver ==  isComplete);
            }
        }
    }
}

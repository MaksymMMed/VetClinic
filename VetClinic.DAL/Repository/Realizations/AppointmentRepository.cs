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
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override Task<Appointment> GetByIdAsync(string id)
        {
            var item = table.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (item == null)
            {
                throw new NotFoundExeption($"Appointment with id {id} not found");
            }

            return item!;
        }
    }
}

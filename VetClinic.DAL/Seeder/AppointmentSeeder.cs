using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;

namespace VetClinic.DAL.Seeder
{
    internal class AppointmentSeeder : ISeeder<Appointment>
    {
        public List<Appointment> Seed() => Appointments;
        List<Appointment> Appointments = new()
        {
            new Appointment
            {
                Id = "4",
                DoctorId = "3",
                AnimalId = "1",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now + TimeSpan.FromHours(2),
                IsOver = true,
            }
        };

    }
}

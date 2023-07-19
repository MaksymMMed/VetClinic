using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;

namespace VetClinic.DAL.Seeder
{
    internal class DoctorSeeder : ISeeder<Doctor>
    {
        public List<Doctor> Seed() => Doctors;

        List<Doctor> Doctors = new()
        {
            new Doctor
            {
                Name = "Lucy",
                NormalizedUserName = "Lucy Gray".ToUpper(),
                UserName = "Lucy Gray",
                Surname = "Gray",
                Email = "LucyGray@gmail.com",
                NormalizedEmail = "LucyGray@gmail.com".ToUpper(),
                PhoneNumber = "0960025653",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                Id = "3",
                SecurityStamp = "123",
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                PasswordHash = "123",
                ConcurrencyStamp = "123",
                LockoutEnabled = false,
                LockoutEnd = null,
            }
        };
    }
}
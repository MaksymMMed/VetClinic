using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;
using VetClinic.DAL.Seeder;

namespace VetClinic.DAL.EntitiesConfigs
{
    internal class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(x => x.NormalizedUserName)
                .IsRequired()
                .HasMaxLength(25);


            builder
                .Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.NormalizedEmail)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(13);

            builder
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x=>x.DoctorId)
                .HasPrincipalKey(x=>x.Id)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasData(new DoctorSeeder().Seed());
        }
    }
}

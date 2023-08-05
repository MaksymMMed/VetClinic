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
    internal class AppoinmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.StartTime)
                .IsRequired();

            builder
                .Property(x => x.EndTime)
                .IsRequired();

            builder
                .Property(x => x.IsOver)
                .IsRequired();

            builder
                .HasOne(x => x.Animal)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Doctor)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.DoctorId)
                .HasPrincipalKey(x=>x.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .OwnsMany(x => x.Procedures, procedure =>
                {
                    // Config for owned type
                    procedure
                        .WithOwner(y => y.Appointment)
                        .HasForeignKey(y => y.AppointmentId);

                    procedure
                        .HasKey(x => x.Id);

                    procedure
                        .Property(x => x.Price)
                        .IsRequired();

                    procedure
                        .Property(x => x.ProcedureName)
                        .HasColumnType("tinyint")
                        .IsRequired();

                    procedure
                        .HasData(new ProcedureSeeder().Seed());

                });

            builder
                .HasData(new AppointmentSeeder().Seed());

        }
    }
}

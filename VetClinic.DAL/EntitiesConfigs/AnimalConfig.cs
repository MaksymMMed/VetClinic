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
    internal class AnimalConfig : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(x=> x.Age)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(300);

            builder
                .Property(x => x.AnimalSex)
                .HasColumnType("tinyint")
                .IsRequired();

            builder
                .Property(x => x.AnimalKind)
                .HasColumnType("tinyint")
                .IsRequired();

            builder
                .HasOne(x => x.Owner)
                .WithMany(x => x.Animals)
                .HasForeignKey(x=>x.OwnerId)
                .HasPrincipalKey(x=>x.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Animal)
                .HasForeignKey(x=>x.AnimalId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasData(new AnimalSeeder().Seed());
        }
    }
}

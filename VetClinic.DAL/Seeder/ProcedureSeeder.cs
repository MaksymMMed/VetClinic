using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;

namespace VetClinic.DAL.Seeder
{
    internal class ProcedureSeeder : ISeeder<Procedure>
    {
        public List<Procedure> Seed() => Procedures;
        List<Procedure> Procedures = new()
        {
            new Procedure
            {
                Id = "5",
                Price = 3500,
                AppointmentId = "4",
                ProcedureName = Procedure.ProcedureType.Spaying
            }
        };
    }
}

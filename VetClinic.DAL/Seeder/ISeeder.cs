using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.DAL.Seeder
{
    internal interface ISeeder<T> where T : class
    {
        public List<T> Seed();
    }
}

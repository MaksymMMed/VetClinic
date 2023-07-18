using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.DAL.Entities
{
    public class Customer:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Animal>? Animals { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;

namespace VetClinic.BLL.Extension
{
    public static class UserManagerExtension
    {
        public static async Task<Customer> FindCustomerByIdAsync(this UserManager<BaseAccount> userManager,string id)
        {
            var Item = await userManager.Users.Cast<Customer>().Include(x=>x.Animals).ThenInclude(x=>x.Appointments).FirstOrDefaultAsync(x=>x.Id == id);
            return Item!;

        }

        public static async Task<Doctor> FindDoctorByIdAsync(this UserManager<BaseAccount> userManager, string id)
        {
            var Item = await userManager.Users.Cast<Doctor>().Include(x => x.Appointments).ThenInclude(x=>x.Animal).FirstOrDefaultAsync(x => x.Id == id);
            return Item!;

        }
    }
}

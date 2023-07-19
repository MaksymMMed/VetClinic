using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography;
using System.Text;
using VetClinic.DAL.Entities;

namespace VetClinic.DAL.Seeder
{
    internal class CustomerSeeder : ISeeder<Customer>
    {
        public List<Customer> Seed() => Customers;

        List<Customer> Customers = new()
        {
            new Customer
            {
                Name = "Walther",
                NormalizedUserName = "Walther White".ToUpper(),
                UserName = "Walther White",
                Surname = "White",
                Email = "WWhite@gmail.com",
                NormalizedEmail = "WWhite@gmail.com".ToUpper(),
                PhoneNumber = "0960025698",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                Id = "2",
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
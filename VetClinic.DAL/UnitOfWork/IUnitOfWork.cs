using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;
using VetClinic.DAL.Repository.Interfaces;

namespace VetClinic.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserManager<BaseAccount> UserManager { get; }

        SignInManager<BaseAccount> SignInManager { get; }

        IAnimalRepository AnimalRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        Task SaveChangesAsync();
    }
}

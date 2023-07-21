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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDatabaseContext Context;

        public UnitOfWork(AppDatabaseContext context, UserManager<BaseAccount> userManager,
            SignInManager<BaseAccount> signInManager, IAnimalRepository animalRepository,
            IAppointmentRepository appointmentRepository)
        {
            Context = context;
            UserManager = userManager;
            SignInManager = signInManager;
            AnimalRepository = animalRepository;
            AppointmentRepository = appointmentRepository;
        }

        public UserManager<BaseAccount> UserManager { get; }
        public SignInManager<BaseAccount> SignInManager { get; }
        public IAnimalRepository AnimalRepository { get; }
        public IAppointmentRepository AppointmentRepository { get; }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}

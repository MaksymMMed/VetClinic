using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BLL.DTO.Response;
using VetClinic.BLL.Services.Interfaces;
using VetClinic.BLL.Extension;
using VetClinic.DAL.Entities;
using VetClinic.DAL.UnitOfWork;
using VetClinic.BLL.DTO.Request;

namespace VetClinic.BLL.Services.Realizations
{
    
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork Unit;
        private readonly IMapper Mapper;

        public CustomerService(IUnitOfWork unit, IMapper mapper)
        {
            Unit = unit;
            Mapper = mapper;
        }

        public async Task DeleteEntityAsync(string id)
        {
            var Item = await Unit.UserManager.FindByIdAsync(id);
            await Unit.SignInManager.UserManager.DeleteAsync(Item!);
            await Unit.SaveChangesAsync();
        }

        public async Task<List<CustomerResponse>> GetAllEntitiesAsync()
        {
            var Item = await Unit.UserManager.Users.Where(x=>x is Customer).Cast<Customer>().Include(x=>x.Animals).ToListAsync();
            return Mapper.Map<List<Customer>,List<CustomerResponse>>(Item);
        }

        public async Task<CustomerResponse> GetEntityByIdAsync(string id)
        {
            var Item = await Unit.UserManager.FindCustomerByIdAsync(id);
            return Mapper.Map<CustomerResponse>(Item);
        }

        public async Task SingIn(SignInRequest request)
        {
            var user = await Unit.UserManager.FindByEmailAsync(request.Email.Trim());

        }

        public Task SingUp(SignUpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

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
using VetClinic.BLL.TokenFactory;
using VetClinic.DAL.Exeptions;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace VetClinic.BLL.Services.Realizations
{
    
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork Unit;
        private readonly IMapper Mapper;
        private readonly IJwtTokenFactory TokenFactory; 

        public CustomerService(IUnitOfWork unit, IMapper mapper, IJwtTokenFactory factory)
        {
            Unit = unit;
            Mapper = mapper;
            TokenFactory = factory;
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

        public async Task<JwtResponse> SingIn(SignInRequest request)
        {
            var user = await Unit.UserManager.FindByEmailAsync(request.Email.Trim());

            if (user is null)
            {
                throw new NotFoundException("User not found");
            }

            if (!await Unit.UserManager.CheckPasswordAsync(user,request.Password.Trim()))
            {
                throw new NotFoundException("Wrong password");
            }

            var JwtToken = TokenFactory.BuildToken(user);
            return new JwtResponse() { Token = SerializeToken(JwtToken) };

        }

        private string SerializeToken(JwtSecurityToken jwtToken) => new JwtSecurityTokenHandler().WriteToken(jwtToken);

        public async Task<JwtResponse> SingUp(SignUpRequest request)
        {
            var user = Mapper.Map<Customer>(request);
            var signUpResult = await Unit.UserManager.CreateAsync(user, request.Password);

            if (!signUpResult.Succeeded)
            {
                string errors = string.Join("\n",
                    signUpResult.Errors.Select(error => error.Description));

                throw new ArgumentException(errors);
            }

            await Unit.SaveChangesAsync();

            var JwtToken = TokenFactory.BuildToken(user);
            return new JwtResponse() { Token = SerializeToken(JwtToken) };

        }
    }
}

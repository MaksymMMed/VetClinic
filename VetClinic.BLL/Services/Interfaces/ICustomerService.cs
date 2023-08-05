using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BLL.DTO.Request;
using VetClinic.BLL.DTO.Response;
using VetClinic.DAL.EntitySearchConditions;

namespace VetClinic.BLL.Services.Interfaces
{
    public interface ICustomerService
    {
        Task SingUp(SignUpRequest request);
        Task SingIn(SignInRequest request);
        Task DeleteEntityAsync(string id);
        Task<CustomerResponse> GetEntityByIdAsync(string id);
        Task<List<CustomerResponse>> GetAllEntitiesAsync();
    }

}

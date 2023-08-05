using Microsoft.AspNetCore.Mvc;
using VetClinic.BLL.Services.Interfaces;

namespace VetClinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerIdentityController:ControllerBase
    {
        private readonly ICustomerService Service;

        public CustomerIdentityController(ICustomerService _Service)
        {
            Service = _Service;
        }



    }
}

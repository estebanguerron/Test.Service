using Microsoft.AspNetCore.Mvc;
using Test.Service.Data.Models;
using Test.Service.Data.Services;

namespace Test.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
               
        private readonly UserService _service;
        private readonly IConfiguration _configuration;

        public UserController(TestContext context, IConfiguration configuration)
        {
            _service = new UserService(context, configuration);
            _configuration = configuration;
        }

        [HttpGet]
        public string Get(string user, string password)  {           
            return _service.Authentication(user, password);          
        }
      


    }
}
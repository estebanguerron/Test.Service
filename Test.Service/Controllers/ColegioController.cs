using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Test.Service.Data.Models;
using Test.Service.Data.Services;
using Test.Service.Help;

namespace Test.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColegioController : ControllerBase
    {
               
        private readonly ColegioService _service;
        private readonly IConfiguration _configuration;
        public ColegioController(TestContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _service = new ColegioService(context);
        }

        [HttpGet]
        public List<Colegio> Get()  {
                     
                return _service.ObtenerColegios();          
        }
        [HttpGet]
        [Route("ObtenerColegio")]
        public Colegio ObtenerColegio(int id)
        {
            return _service.ObtenerColegio(id);
        }


        [HttpDelete]
        [Route("EliminarColegio")]
        public bool EliminarColegio(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            TokenJwt tokenJwt = new TokenJwt(_configuration);
            if( tokenJwt.ValidarToken(identity))
                 return _service.EliminarColegio(id);
            else 
                return false;
        }

        [HttpPut]
        [Route("GrabarColegio")]
        public bool GrabarColegio(Colegio colegio)
        {          
            return _service.GrabarColegio(colegio);
        }



    }
}
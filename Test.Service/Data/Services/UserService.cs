
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test.Service.Data.Interfaces;
using Test.Service.Data.Models;
using Test.Service.Help;

namespace Test.Service.Data.Services
{
    public class UserService : IUserService
    {
        private readonly TestContext _db;
        private readonly IConfiguration _configuration;
        public UserService(TestContext db, IConfiguration configuration) { 
            _db = db;
            _configuration = configuration;
        }
        public string Authentication(string user, string password)
        {            
            var users = _db.Usuarios.Where(x => x.Username== user && x.Password == password).ToList();
            
            TokenJwt tokenJwt = new TokenJwt(_configuration);          
            if (users.Count==1)
                 return tokenJwt.GenerarToken(user);
            else
                return "Usuario No Autorizado";
        }


    }
}

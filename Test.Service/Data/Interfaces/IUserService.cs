using Test.Service.Data.Models;

namespace Test.Service.Data.Interfaces
{
    public interface IUserService
    {
        public string Authentication(string user, string password);
 
    }
}

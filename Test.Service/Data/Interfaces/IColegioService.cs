using Test.Service.Data.Models;

namespace Test.Service.Data.Interfaces
{
    public interface IColegioService
    {
        public List<Colegio> ObtenerColegios();
        public Colegio ObtenerColegio(int id);
        public bool EliminarColegio(int id);
        public bool GrabarColegio(Colegio colegio);
    }
}

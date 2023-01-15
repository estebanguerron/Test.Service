using Microsoft.EntityFrameworkCore;
using Test.Service.Data.Interfaces;
using Test.Service.Data.Models;

namespace Test.Service.Data.Services
{
    public class ColegioService : IColegioService
    {
        private readonly TestContext _db;
        public ColegioService(TestContext db ) { 
            _db = db;
        }
        public List<Colegio> ObtenerColegios()
        {
             return _db.Colegios.ToList();
        }

        public Colegio ObtenerColegio(int id)
        {           
            var colegio = _db.Colegios.FirstOrDefault(x => x.Id == id);
            if (colegio == null) { colegio = new Colegio(); }
            return colegio;
           
        }

        public bool EliminarColegio(int id)
        {
            try
            {             
               var colegio = _db.Colegios.SingleOrDefault(x => x.Id == id); 

                if (colegio != null)
                {
                    _db.Colegios.Remove(colegio);
                    _db.SaveChanges();
                    return true;
                }
                else 
                { 
                    return false; 
                }                
            }
            catch { return false; }


        }
        public bool GrabarColegio(Colegio colegio)
        {
            try
            {
                if (colegio != null)
                {
                     var colegioActualizar = _db.Colegios.SingleOrDefault(x => x.Nombre == colegio.Nombre && x.Id==colegio.Id);
                    if (colegioActualizar != null)
                    {
                        colegioActualizar.TipoColegio = colegio.TipoColegio;
                        _db.Entry(colegioActualizar).State = EntityState.Modified;
                    }
                    else
                    {
                        colegio.Id = 0;
                        _db.Colegios.Add(colegio);
                    }
                                    
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
    }
}

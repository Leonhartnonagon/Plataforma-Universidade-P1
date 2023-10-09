using DDD.Domain.SecretariaContext;
using DDD.Domain.TiContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IChamadorRepository
    {
        public List<Chamador> GetChamadores();
        public Chamador GetChamadorById(int id);
        public void InsertChamador(Chamador chamador);
        public void UpdateChamador(Chamador chamador);
        public void DeleteChamador(Chamador chamador);
    }
}

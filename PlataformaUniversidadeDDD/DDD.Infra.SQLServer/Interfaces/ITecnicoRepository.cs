using DDD.Domain.SecretariaContext;
using DDD.Domain.TiContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ITecnicoRepository
    {
        public List<Tecnico> GetTecnicos();
        public Tecnico GetTecnicoById(int id);
        public void InsertTecnico(Tecnico tecnico);
        public void UpdateTecnico(Tecnico tecnico);
        public void DeleteTecnico(Tecnico tecnico);
    }
}

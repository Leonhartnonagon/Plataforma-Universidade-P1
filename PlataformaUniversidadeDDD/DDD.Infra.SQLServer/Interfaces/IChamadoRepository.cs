using DDD.Domain.SecretariaContext;
using DDD.Domain.TiContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IChamadoRepository
    {
        public List<Chamado> GetChamados();
        public Chamado GetChamadoById(int id);
        //public void InsertMatricula(Matricula matricula);
        public Chamado InsertChamado(int idChamador);
        public void UpdateChamado(Chamado chamado);
        //public void AssignTecnico(Chamado camado, int idTecnico);
        public void DeleteChamado(Chamado chamado);
    }
}

using DDD.Domain.SecretariaContext;
using DDD.Domain.TiContext;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class ChamadoRepositorySqlServer : IChamadoRepository
    {
        private readonly SqlContext _context;

        public ChamadoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteChamado(Chamado chamado)
        {
            throw new NotImplementedException();
        }

        public Chamado GetChamadoById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Chamado> GetChamados()
        {
            throw new NotImplementedException();
        }

        public Chamado InsertChamado(int idAluno, int idDisciplina)
        {
            var aluno = _context.Alunos.First(i => i.UserId == idAluno);
            var disciplina = _context.Disciplinas.First(i => i.DisciplinaId == idDisciplina);

            var chamado = new Chamado
            {
                Aluno = aluno,
                Disciplina = disciplina
            };

            try
            {

                _context.Add(chamado);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return chamado;
        }

        public void UpdateChamado(Chamado chamado)
        {
            throw new NotImplementedException();
        }
    }
}
}

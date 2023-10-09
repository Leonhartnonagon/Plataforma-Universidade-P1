using DDD.Domain.SecretariaContext;
using DDD.Domain.TiContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class TecnicoRepositorySqlServer : ITecnicoRepository
    {
        

        private readonly SqlContext _context;

        public TecnicoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteTecnico(Tecnico tecnico)
        {
            try
            {
                _context.Set<Tecnico>().Remove(tecnico);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Tecnico GetTecnicoById(int id)
        {
            return _context.Tecnicos.Find(id);
        }

        public List<Tecnico> GetTecnicos()
        {
            //return  _context.Tecnicos.Include(x => x.Disciplinas).ToList();
            return _context.Tecnicos.ToList();

        }

        public void InsertTecnico(Tecnico tecnico)
        {
            try
            {
                _context.Tecnicos.Add(tecnico);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateTecnico(Tecnico tecnico)
        {
            try
            {
                _context.Entry(tecnico).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
}

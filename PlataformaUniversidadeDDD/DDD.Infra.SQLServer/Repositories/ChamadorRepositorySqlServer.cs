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
    public class ChamadorRepositorySqlServer : IChamadorRepository
    {
        private readonly SqlContext _context;

        public ChamadorRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteChamador(Chamador chamador)
        {
            try
            {
                _context.Set<Chamador>().Remove(chamador);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Chamador GetChamadorById(int id)
        {
            return _context.Chamadores.Find(id);
        }

        public List<Chamador> GetChamadores()
        {
            //return  _context.Chamadores.Include(x => x.Disciplinas).ToList();
            return _context.Chamadores.ToList();

        }

        public void InsertChamador(Chamador chamador)
        {
            try
            {
                _context.Chamadores.Add(chamador);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateChamador(Chamador chamador)
        {
            try
            {
                _context.Entry(chamador).State = EntityState.Modified;
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

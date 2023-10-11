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
    public class ChamadoRepositorySqlServer : IChamadoRepository
    {
        private readonly SqlContext _context;

        public ChamadoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteChamado(Chamado chamado)
        {
            try
            {
                _context.Set<Chamado>().Remove(chamado);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Chamado GetChamadoById(int id)
        {
            return _context.Chamados.Find(id);
        }

        public List<Chamado> GetChamados()
        {
            return _context.Chamados.ToList();
        }

        public void InsertChamado(Chamado chamado)
        {

            try
            {
                _context.Chamados.Add(chamado);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }

        }

        public void UpdateChamado(Chamado chamado)
        {
            try
            {
                _context.Entry(chamado).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public void AssignTecnico(Chamado camado, int idTecnico)
        //{

        //}
    }
}


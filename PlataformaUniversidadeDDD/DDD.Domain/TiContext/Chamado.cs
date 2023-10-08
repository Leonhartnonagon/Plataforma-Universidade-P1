using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.TiContext
{
    public class Chamado
    {
        public int IdChamado { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Resolvido { get; set; }
        public List<Chamador> Chamador { get; set; }
        public List<Tecnico>? Tecnico { get; set; }
    }
}

using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.TiContext
{
    public class Chamado
    {
        public int IdChamado { get; set; }
        public int IdChamador { get; set; }
        public int? IdTecnico { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Resolvido { get; set; }
        public Chamador Chamador { get; set; }
        public Tecnico? Tecnico { get; set; }
    }
}

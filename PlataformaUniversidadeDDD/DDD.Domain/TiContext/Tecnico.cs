﻿using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.TiContext
{
    public class Tecnico : User
    {
        public List<Chamado>? Chamados { get; set; }
    }
}

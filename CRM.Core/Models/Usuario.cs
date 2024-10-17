﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Usuario
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public DateTime DataInclusao { get; set; }
    }
}

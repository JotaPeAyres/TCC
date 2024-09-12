﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Cidade
    {

        public Guid Id { get; set; }

        public DateTime DataInclusao { get; set; }
        public string Nome { get; set; }

        [ForeignKey("Estado")]
        public Guid estadoId { get; set; }
        public virtual Estado Estado { get; set; }

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }
    }
}
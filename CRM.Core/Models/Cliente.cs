using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Cliente
    {

        public Guid Id { get; set; }

        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual User UsuarioInclusao { get; set; }

        public DateTime DataInclusao { get; set; }

        [ForeignKey("EnderecoCliente")]
        public Guid enderecoClienteId { get; set; }
        public virtual EnderecoCliente EnderecoCliente { get; set; }
    }
}

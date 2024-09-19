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

        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Documento { get; set; }

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }

        public DateTime DataInclusao { get; set; }

        [ForeignKey("EnderecoCliente")]
        public Guid enderecoClienteId { get; set; }
        public virtual EnderecoCliente EnderecoCliente { get; set; }
    }
}

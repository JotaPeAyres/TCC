using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class EnderecoCliente
    {

        public Guid Id { get; set; }
        public string Numero { get; set; }
        public string Cep {  get; set; }

        public DateTime DataInclusao { get; set; }

        [ForeignKey("Cliente")]
        public Guid clienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("Estado")]
        public Guid estadoId { get; set; }
        public virtual Estado Estado { get; set; }

        [ForeignKey("Cidade")]
        public Guid cidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }
    }
}

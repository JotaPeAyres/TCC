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
        public string Logradouro { get; set; } = string.Empty;
        public string Cep {  get; set; } = string.Empty;

        public DateTime DataInclusao { get; set; }

        [ForeignKey("Estado")]
        public Guid estadoId { get; set; }
        public virtual Estado Estado { get; set; }

        [ForeignKey("Cidade")]
        public Guid cidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual User UsuarioInclusao { get; set; }
    }
}

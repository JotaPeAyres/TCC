using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [ForeignKey("Proposta")]
        public Guid PropostaId { get; set; }
        public virtual Proposta Proposta { get; set; }

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}

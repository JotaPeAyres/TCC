using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Proposta
    {

        public Guid Id { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }

        [ForeignKey("StatusProposta")]
        public Guid statusPropostaId { get; set; }
        public virtual StatusProposta StatusProposta { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}

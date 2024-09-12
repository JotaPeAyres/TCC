using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class StatusProposta
    {

        public Guid Id { get; set; }

        public string NomeStatus { get; set; }

        public int codigo { get; set; }

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}

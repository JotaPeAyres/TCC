using System;
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

        public string Name { get; set; }

        public string Senha { get; set; }

        public DateTime DataInclusao { get; set; }

        //Acho que não precisa desse usuario de inclusão
        //[ForeignKey("usuarioInclusao")]
        //public Guid usuarioInclusaoId { get; set; }
        //public virtual Usuario UsuarioInclusao { get; set; }
    }
}

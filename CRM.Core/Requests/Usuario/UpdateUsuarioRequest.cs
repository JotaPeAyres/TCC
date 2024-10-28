using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Requests.Usuario
{
    public class UpdateUsuarioRequest : Request
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Login inválido")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha inválida")]
        public string Senha { get; set; } = string.Empty;
    }
}

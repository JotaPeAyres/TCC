using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Requests.Usuario
{
    public class CreateUsuarioRequest : Request
    {
        public string Name { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;
    }
}

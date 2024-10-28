using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Requests.Usuario
{
    public class DeleteUsuarioRequest : Request
    {
        public Guid Id { get; set; }
    }
}

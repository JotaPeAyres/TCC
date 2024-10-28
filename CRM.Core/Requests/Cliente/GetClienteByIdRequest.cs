using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Requests.Cliente
{
    public class GetClienteByIdRequest : Request
    {
        public Guid Id { get; set; }
    }
}

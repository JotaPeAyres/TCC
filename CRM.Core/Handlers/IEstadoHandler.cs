using CRM.Core.Models;
using CRM.Core.Requests.Estados;
using CRM.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Handlers;

public interface IEstadoHandler
{
    Task<Response<Estado?>> CreateAsync(CreateEstadoRequest request);
    Task<Response<Estado?>> UpdateAsync(UpdateEstadoRequest request);
    Task<Response<Estado?>> DeleteAsync(DeleteEstadoRequest request);
    Task<Response<Estado?>> GetByIdAsync(GetEstadoByIdRequest request);
    Task<PagedResponse<List<Estado>?>> GetAllAsync(GetAllEstadosRequest request);
}

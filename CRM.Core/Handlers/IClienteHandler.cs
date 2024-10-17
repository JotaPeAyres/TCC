using CRM.Core.Models;
using CRM.Core.Requests.Cliente;
using CRM.Core.Responses;

namespace CRM.Core.Handlers
{
    public interface IClienteHandler
    {
        Task<Response<Cliente?>> CreateAsync(CreateClienteRequest request);
        Task<Response<Cliente?>> UpdateAsync(UpdateClienteRequest request);
        Task<Response<Cliente?>> DeleteAsync(DeleteClienteRequest request);
        Task<Response<Cliente?>> GetByIdAsync(GetClienteByIdRequest request);
        Task<PagedResponse<List<Cliente>?>> GetAllAsync(GetAllClientesRequest request);
    }
}

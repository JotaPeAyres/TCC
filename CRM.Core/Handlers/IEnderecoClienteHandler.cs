using CRM.Core.Models;
using CRM.Core.Requests.EnderecoCliente;
using CRM.Core.Responses;

namespace CRM.Core.Handlers
{
    public interface IEnderecoClienteHandler
    {
        Task<Response<EnderecoCliente?>> CreateAsync(CreateEnderecoClienteRequest request);
        Task<Response<EnderecoCliente?>> UpdateAsync(UpdateEnderecoClienteRequest request);
        Task<Response<EnderecoCliente?>> DeleteAsync(DeleteEnderecoClienteRequest request);
        Task<Response<EnderecoCliente?>> GetByIdAsync(GetEnderecoClienteByIdRequest request);
        Task<PagedResponse<List<EnderecoCliente>?>> GetAllAsync(GetAllEnderecoClienteRequest request);
    }
}

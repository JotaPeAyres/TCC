using CRM.Core.Models;
using CRM.Core.Requests.Cidades;
using CRM.Core.Responses;

namespace CRM.Core.Handlers
{
    public interface ICidadeHandler
    {
        Task<Response<Cidade?>> CreateAsync(CreateCidadeRequest request);
        Task<Response<Cidade?>> UpdateAsync(UpdateCidadeRequest request);
        Task<Response<Cidade?>> DeleteAsync(DeleteCidadeRequest request);
        Task<Response<Cidade?>> GetByIdAsync(GetCidadeByIdRequest request);
        Task<PagedResponse<List<Cidade>?>> GetAllAsync(GetAllCidadesRequest request);
    }
}
using CRM.Core.Models;
using CRM.Core.Requests.Proposta;
using CRM.Core.Responses;

namespace CRM.Core.Handlers
{
    public interface IPropostaHandler
    {
        Task<Response<Proposta?>> CreateAsync(CreatePropostaRequest request);
        Task<Response<Proposta?>> UpdateAsync(UpdatePropostaRequest request);
        Task<Response<Proposta?>> DeleteAsync(DeletePropostaRequest request);
        Task<Response<Proposta?>> GetByIdAsync(GetPropostaByIdRequest request);
        Task<PagedResponse<List<Proposta>?>> GetAllAsync(GetAllPropostasRequest request);
    }
}

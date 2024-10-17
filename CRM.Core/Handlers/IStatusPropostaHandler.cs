using CRM.Core.Models;
using CRM.Core.Responses;
using CRM.Core.Requests.StatusProposta;

namespace CRM.Core.Handlers
{
    public interface IStatusPropostaHandler
    {
        Task<Response<StatusProposta?>> CreateAsync(CreateStatusPropostaRequest request);
        Task<Response<StatusProposta?>> UpdateAsync(UpdateStatusPropostaRequest request);
        Task<Response<StatusProposta?>> DeleteAsync(DeleteStatusPropostaRequest request);
        Task<Response<StatusProposta?>> GetByIdAsync(GetStatusPropostaByIdRequest request);
        Task<PagedResponse<List<StatusProposta>?>> GetAllAsync(GetAllStatusPropostaRequest request);
    }
}

using CRM.Core.Models;
using CRM.Core.Requests.Agenda;
using CRM.Core.Responses;

namespace CRM.Core.Handlers
{
    public interface IAgendaHandler
    {
        Task<Response<Agenda?>> CreateAsync(CreateAgendaRequest request);
        Task<Response<Agenda?>> UpdateAsync(UpdateAgendaRequest request);
        Task<Response<Agenda?>> DeleteAsync(DeleteAgendaRequest request);
        Task<Response<Agenda?>> GetByIdAsync(GetAgendaByIdRequest request);
        Task<PagedResponse<List<Agenda>?>> GetAllAsync(GetAllAgendasRequest request);
    }
}

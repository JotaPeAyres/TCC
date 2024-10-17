using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Agenda;
using CRM.Core.Responses;

namespace CRM.Web.Handlers;

public class AgendaHandler : IAgendaHandler
{
    public Task<Response<Agenda?>> CreateAsync(CreateAgendaRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Agenda?>> DeleteAsync(DeleteAgendaRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Agenda>?>> GetAllAsync(GetAllAgendasRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Agenda?>> GetByIdAsync(GetAgendaByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Agenda?>> UpdateAsync(UpdateAgendaRequest request)
    {
        throw new NotImplementedException();
    }
}

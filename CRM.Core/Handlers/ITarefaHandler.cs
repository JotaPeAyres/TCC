using CRM.Core.Models;
using CRM.Core.Requests.Tarefa;
using CRM.Core.Responses;

namespace CRM.Core.Handlers
{
    public interface ITarefaHandler
    {
        Task<Response<Tarefa?>> CreateAsync(CreateTarefaRequest request);
        Task<Response<Tarefa?>> UpdateAsync(UpdateTarefaRequest request);
        Task<Response<Tarefa?>> DeleteAsync(DeleteTarefaRequest request);
        Task<Response<Tarefa?>> GetByIdAsync(GetTarefaByIdRequest request);
        Task<PagedResponse<List<Tarefa>?>> GetAllAsync(GetAllTarefasRequest request);
    }
}

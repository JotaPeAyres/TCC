using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Tarefa;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;

public class TarefaHandler(IHttpClientFactory httpClientFactory) : ITarefaHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Tarefa?>> CreateAsync(CreateTarefaRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/tarefa", request);
        return await result.Content.ReadFromJsonAsync<Response<Tarefa?>>()
            ?? new Response<Tarefa?>(null, 400, "Falha ao criar tarefa");
    }

    public async Task<Response<Tarefa?>> DeleteAsync(DeleteTarefaRequest request)
    {
        var result = await _client.DeleteAsync($"v1/tarefa/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Tarefa?>>()
            ?? new Response<Tarefa?>(null, 400, "Falha ao excluir tarefa");
    }

    public async Task<PagedResponse<List<Tarefa>?>> GetAllAsync(GetAllTarefasRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Tarefa>?>>($"vi/tarefa/")
            ?? new PagedResponse<List<Tarefa>?>(null, 400, "Não foi possível obter todas as tarefas");

    public async Task<Response<Tarefa?>> GetByIdAsync(GetTarefaByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Tarefa?>>($"vi/tarefa/{request.Id}")
            ?? new Response<Tarefa?>(null, 400, "Não foi possível obter a tarefa");

    public async Task<Response<Tarefa?>> UpdateAsync(UpdateTarefaRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/tarefa/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Tarefa?>>()
            ?? new Response<Tarefa?>(null, 400, "Falha ao atualizar a tarefa");
    }
}
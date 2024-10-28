using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Agenda;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;

public class AgendaHandler(IHttpClientFactory httpClientFactory) : IAgendaHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Agenda?>> CreateAsync(CreateAgendaRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/agenda", request);
        return await result.Content.ReadFromJsonAsync<Response<Agenda?>>()
            ?? new Response<Agenda?>(null, 400, "Falha ao criar agenda");
    }

    public async Task<Response<Agenda?>> DeleteAsync(DeleteAgendaRequest request)
    {
        var result = await _client.DeleteAsync($"v1/agenda/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Agenda?>>()
            ?? new Response<Agenda?>(null, 400, "Falha ao excluir agenda");
    }

    public async Task<PagedResponse<List<Agenda>?>> GetAllAsync(GetAllAgendasRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Agenda>?>>($"vi/agenda/")
            ?? new PagedResponse<List<Agenda>?>(null, 400, "Não foi possível obter todas as agendas");

    public async Task<Response<Agenda?>> GetByIdAsync(GetAgendaByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Agenda?>>($"vi/agenda/{request.Id}")
            ?? new Response<Agenda?>(null, 400, "Não foi possível obter a agenda");

    public async Task<Response<Agenda?>> UpdateAsync(UpdateAgendaRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/agenda/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Agenda?>>()
            ?? new Response<Agenda?>(null, 400, "Falha ao atualizar a agenda");
    }
}

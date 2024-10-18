using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.StatusProposta;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;

public class StatusPropostaHandler(IHttpClientFactory httpClientFactory) : IStatusPropostaHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<StatusProposta?>> CreateAsync(CreateStatusPropostaRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/statusProposta", request);
        return await result.Content.ReadFromJsonAsync<Response<StatusProposta?>>()
            ?? new Response<StatusProposta?>(null, 400, "Falha ao criar status da proposta");
    }

    public async Task<Response<StatusProposta?>> DeleteAsync(DeleteStatusPropostaRequest request)
    {
        var result = await _client.DeleteAsync($"v1/statusProposta/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<StatusProposta?>>()
            ?? new Response<StatusProposta?>(null, 400, "Falha ao excluir status da proposta");
    }

    public async Task<PagedResponse<List<StatusProposta>?>> GetAllAsync(GetAllStatusPropostaRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<StatusProposta>?>>($"vi/statusProposta/")
            ?? new PagedResponse<List<StatusProposta>?>(null, 400, "Não foi possível obter todos os status da proposta");

    public async Task<Response<StatusProposta?>> GetByIdAsync(GetStatusPropostaByIdRequest request)
        => await _client.GetFromJsonAsync<Response<StatusProposta?>>($"vi/statusProposta/{request.Id}")
            ?? new Response<StatusProposta?>(null, 400, "Não foi possível obter o status da proposta");

    public async Task<Response<StatusProposta?>> UpdateAsync(UpdateStatusPropostaRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/statusProposta/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<StatusProposta?>>()
            ?? new Response<StatusProposta?>(null, 400, "Falha ao atualizar status da proposta");
    }
}
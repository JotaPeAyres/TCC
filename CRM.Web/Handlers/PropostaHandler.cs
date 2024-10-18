using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Proposta;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;

public class PropostaHandler(IHttpClientFactory httpClientFactory) : IPropostaHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Proposta?>> CreateAsync(CreatePropostaRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/proposta", request);
        return await result.Content.ReadFromJsonAsync<Response<Proposta?>>()
            ?? new Response<Proposta?>(null, 400, "Falha ao criar proposta");
    }

    public async Task<Response<Proposta?>> DeleteAsync(DeletePropostaRequest request)
    {
        var result = await _client.DeleteAsync($"v1/proposta/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Proposta?>>()
            ?? new Response<Proposta?>(null, 400, "Falha ao excluir proposta");
    }

    public async Task<PagedResponse<List<Proposta>?>> GetAllAsync(GetAllPropostasRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Proposta>?>>($"vi/proposta/")
            ?? new PagedResponse<List<Proposta>?>(null, 400, "Não foi possível obter as propostas");

    public async Task<Response<Proposta?>> GetByIdAsync(GetPropostaByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Proposta?>>($"vi/proposta/{request.Id}")
            ?? new Response<Proposta?>(null, 400, "Não foi possível obter a proposta");

    public async Task<Response<Proposta?>> UpdateAsync(UpdatePropostaRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/proposta/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Proposta?>>()
            ?? new Response<Proposta?>(null, 400, "Falha ao atualizar proposta");
    }
}

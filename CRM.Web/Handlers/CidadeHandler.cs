using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cidades;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;

public class CidadeHandler(IHttpClientFactory httpClientFactory) : ICidadeHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

    public async Task<Response<Cidade?>> CreateAsync(CreateCidadeRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/cidades", request);
        return await result.Content.ReadFromJsonAsync<Response<Cidade?>>() 
            ?? new Response<Cidade?>(null, 400, "Falha ao criar cidade");
    }

    public async Task<Response<Cidade?>> DeleteAsync(DeleteCidadeRequest request)
    {
        var result = await _client.DeleteAsync($"v1/cidades/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Cidade?>>()
            ?? new Response<Cidade?>(null, 400, "Falha ao excluir cidade");
    }

    public async Task<PagedResponse<List<Cidade>?>> GetAllAsync(GetAllCidadesRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Cidade>?>>($"vi/cidades/")
            ?? new PagedResponse<List<Cidade>?>(null, 400, "Não foi possível obter as cidades");

    public async Task<Response<Cidade?>> GetByIdAsync(GetCidadeById request)
        => await _client.GetFromJsonAsync<Response<Cidade?>>($"vi/cidades/{request.Id}")
            ?? new Response<Cidade?>(null, 400, "Não foi possível obter a cidade");

    public async Task<Response<Cidade?>> UpdateAsync(UpdateCidadeRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/cidades/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Cidade?>>() 
            ?? new Response<Cidade?>(null, 400, "Falha ao atualizar cidade");
    }
}

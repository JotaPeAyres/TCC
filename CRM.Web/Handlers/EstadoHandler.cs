using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Estados;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;

public class EstadoHandler(IHttpClientFactory httpClientFactory) : IEstadoHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

    public async Task<Response<Estado?>> CreateAsync(CreateEstadoRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/Estados", request);
        return await result.Content.ReadFromJsonAsync<Response<Estado?>>()
            ?? new Response<Estado?>(null, 400, "Falha ao criar Estado");
    }

    public async Task<Response<Estado?>> DeleteAsync(DeleteEstadoRequest request)
    {
        var result = await _client.DeleteAsync($"v1/Estados/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Estado?>>()
            ?? new Response<Estado?>(null, 400, "Falha ao excluir Estado");
    }

    public async Task<PagedResponse<List<Estado>?>> GetAllAsync(GetAllEstadosRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Estado>?>>($"vi/Estados/")
            ?? new PagedResponse<List<Estado>?>(null, 400, "Não foi possível obter as Estados");

    public async Task<Response<Estado?>> GetByIdAsync(GetEstadoByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Estado?>>($"vi/Estados/{request.Id}")
            ?? new Response<Estado?>(null, 400, "Não foi possível obter a Estado");

    public async Task<Response<Estado?>> UpdateAsync(UpdateEstadoRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/Estados/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Estado?>>()
            ?? new Response<Estado?>(null, 400, "Falha ao atualizar Estado");
    }
}

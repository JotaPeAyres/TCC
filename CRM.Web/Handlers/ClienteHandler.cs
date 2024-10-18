using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cliente;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;

public class ClienteHandler(IHttpClientFactory httpClientFactory) : IClienteHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Cliente?>> CreateAsync(CreateClienteRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/cliente", request);
        return await result.Content.ReadFromJsonAsync<Response<Cliente?>>()
            ?? new Response<Cliente?>(null, 400, "Falha ao criar cliente");
    }

    public async Task<Response<Cliente?>> DeleteAsync(DeleteClienteRequest request)
    {
        var result = await _client.DeleteAsync($"v1/cliente/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Cliente?>>()
            ?? new Response<Cliente?>(null, 400, "Falha ao excluir cliente");
    }

    public async Task<PagedResponse<List<Cliente>?>> GetAllAsync(GetAllClientesRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Cliente>?>>($"vi/cliente/")
            ?? new PagedResponse<List<Cliente>?>(null, 400, "Não foi possível obter os clientes");

    public async Task<Response<Cliente?>> GetByIdAsync(GetClienteByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Cliente?>>($"vi/cliente/{request.Id}")
            ?? new Response<Cliente?>(null, 400, "Não foi possível obter o cliente");

    public async Task<Response<Cliente?>> UpdateAsync(UpdateClienteRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/cliente/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Cliente?>>()
            ?? new Response<Cliente?>(null, 400, "Falha ao atualizar cliente");
    }
}

using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Pedido;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;

public class PedidoHandler(IHttpClientFactory httpClientFactory) : IPedidoHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Pedido?>> CreateAsync(CreatePedidoRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/pedido", request);
        return await result.Content.ReadFromJsonAsync<Response<Pedido?>>()
            ?? new Response<Pedido?>(null, 400, "Falha ao criar pedido");
    }

    public async Task<Response<Pedido?>> DeleteAsync(DeletePedidoRequest request)
    {
        var result = await _client.DeleteAsync($"v1/pedido/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Pedido?>>()
            ?? new Response<Pedido?>(null, 400, "Falha ao excluir pedido");
    }

    public async Task<PagedResponse<List<Pedido>?>> GetAllAsync(GetAllPedidoRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Pedido>?>>($"vi/pedido/")
            ?? new PagedResponse<List<Pedido>?>(null, 400, "Não foi possível obter os pedidos");

    public async Task<Response<Pedido?>> GetByIdAsync(GetPedidoByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Pedido?>>($"vi/pedido/{request.Id}")
            ?? new Response<Pedido?>(null, 400, "Não foi possível obter o pedido");

    public async Task<Response<Pedido?>> UpdateAsync(UpdatePedidoRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/pedido/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Pedido?>>()
            ?? new Response<Pedido?>(null, 400, "Falha ao atualizar pedido");
    }
}

using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.ProdutoProposta;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;
public class ProdutoPropostaHandler(IHttpClientFactory httpClientFactory) : IProdutoPropostaHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<ProdutoProposta?>> CreateAsync(CreateProdutoPropostaRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/produtoProposta", request);
        return await result.Content.ReadFromJsonAsync<Response<ProdutoProposta?>>()
            ?? new Response<ProdutoProposta?>(null, 400, "Falha ao criar produto da proposta");
    }

    public async Task<Response<ProdutoProposta?>> DeleteAsync(DeleteProdutoPropostaRequest request)
    {
        var result = await _client.DeleteAsync($"v1/produtoProposta/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<ProdutoProposta?>>()
            ?? new Response<ProdutoProposta?>(null, 400, "Falha ao excluir produto da proposta");
    }

    public async Task<PagedResponse<List<ProdutoProposta>?>> GetAllAsync(GetAllProdutoPropostaRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<ProdutoProposta>?>>($"vi/produtoProposta/")
            ?? new PagedResponse<List<ProdutoProposta>?>(null, 400, "Não foi possível obter os produtos das propostas");

    public async Task<Response<ProdutoProposta?>> GetByIdAsync(GetProdutoPropostaByIdRequest request)
        => await _client.GetFromJsonAsync<Response<ProdutoProposta?>>($"vi/produtoProposta/{request.Id}")
            ?? new Response<ProdutoProposta?>(null, 400, "Não foi possível obter o produto da proposta");

    public async Task<Response<ProdutoProposta?>> UpdateAsync(UpdateProdutoPropostaRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/produtoProposta/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<ProdutoProposta?>>()
            ?? new Response<ProdutoProposta?>(null, 400, "Falha ao atualizar produto da proposta");
    }
}

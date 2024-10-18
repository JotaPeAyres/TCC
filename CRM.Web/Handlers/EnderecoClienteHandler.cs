using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cliente;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers
{
    public class EnderecoClienteHandler(IHttpClientFactory httpClientFactory) : IEnderecoClienteHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public async Task<Response<EnderecoCliente?>> CreateAsync(CreateClienteRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/enderecoCliente", request);
            return await result.Content.ReadFromJsonAsync<Response<EnderecoCliente?>>()
                ?? new Response<EnderecoCliente?>(null, 400, "Falha ao criar endereço do cliente");
        }

        public async Task<Response<EnderecoCliente?>> DeleteAsync(DeleteClienteRequest request)
        {
            var result = await _client.DeleteAsync($"v1/enderecoCliente/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<EnderecoCliente?>>()
                ?? new Response<EnderecoCliente?>(null, 400, "Falha ao excluir endereço do cliente");
        }

        public async Task<PagedResponse<List<EnderecoCliente>?>> GetAllAsync(GetAllClientesRequest request)
            => await _client.GetFromJsonAsync<PagedResponse<List<EnderecoCliente>?>>($"vi/enderecoCliente/")
                ?? new PagedResponse<List<EnderecoCliente>?>(null, 400, "Não foi possível obter os endereços dos clientes");

        public async Task<Response<EnderecoCliente?>> GetByIdAsync(GetClienteByIdRequest request)
            => await _client.GetFromJsonAsync<Response<EnderecoCliente?>>($"vi/enderecoCliente/{request.Id}")
                ?? new Response<EnderecoCliente?>(null, 400, "Não foi possível obter o endereço do cliente");

        public async Task<Response<EnderecoCliente?>> UpdateAsync(UpdateClienteRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/enderecoCliente/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<EnderecoCliente?>>()
                ?? new Response<EnderecoCliente?>(null, 400, "Falha ao atualizar endereço do cliente");
        }
    }
}

using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cliente;
using CRM.Core.Responses;

namespace CRM.Web.Handlers;

public class ClienteHandler(IHttpClientFactory httpClientFactory) : IClienteHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public Task<Response<Cliente?>> CreateAsync(CreateClienteRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Cliente?>> DeleteAsync(DeleteClienteRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Cliente>?>> GetAllAsync(GetAllClientesRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Cliente?>> GetByIdAsync(GetClienteByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Cliente?>> UpdateAsync(UpdateClienteRequest request)
    {
        throw new NotImplementedException();
    }
}

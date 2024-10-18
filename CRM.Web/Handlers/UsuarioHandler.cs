using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Usuario;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;
public class UsuarioHandler(IHttpClientFactory httpClientFactory) : IUsuarioHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Usuario?>> CreateAsync(CreateUsuarioRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/usuario", request);
        return await result.Content.ReadFromJsonAsync<Response<Usuario?>>()
            ?? new Response<Usuario?>(null, 400, "Falha ao criar usuário");
    }

    public async Task<Response<Usuario?>> DeleteAsync(DeleteUsuarioRequest request)
    {
        var result = await _client.DeleteAsync($"v1/usuario/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Usuario?>>()
            ?? new Response<Usuario?>(null, 400, "Falha ao excluir usuário");
    }

    public async Task<PagedResponse<List<Usuario>?>> GetAllAsync(GetAllUsuariosRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Usuario>?>>($"vi/usuario/")
            ?? new PagedResponse<List<Usuario>?>(null, 400, "Não foi possível obter todos os usuários");

    public async Task<Response<Usuario?>> GetByIdAsync(GetUsuarioByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Usuario?>>($"vi/usuario/{request.Id}")
            ?? new Response<Usuario?>(null, 400, "Não foi possível obter o usuário");

    public async Task<Response<Usuario?>> UpdateAsync(UpdateUsuarioRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/usuario/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Usuario?>>()
            ?? new Response<Usuario?>(null, 400, "Falha ao atualizar usuário");
    }
}
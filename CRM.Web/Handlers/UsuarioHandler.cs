using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Usuario;
using CRM.Core.Responses;
using System.Net.Http.Json;

namespace CRM.Web.Handlers;
public class UsuarioHandler(IHttpClientFactory httpClientFactory) : IUsuarioHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<User?>> CreateAsync(CreateUsuarioRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/usuario", request);
        return await result.Content.ReadFromJsonAsync<Response<User?>>()
            ?? new Response<User?>(null, 400, "Falha ao criar usuário");
    }

    public async Task<Response<User?>> DeleteAsync(DeleteUsuarioRequest request)
    {
        var result = await _client.DeleteAsync($"v1/usuario/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<User?>>()
            ?? new Response<User?>(null, 400, "Falha ao excluir usuário");
    }

    public async Task<PagedResponse<List<User>?>> GetAllAsync(GetAllUsuariosRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<User>?>>($"vi/usuario/")
            ?? new PagedResponse<List<User>?>(null, 400, "Não foi possível obter todos os usuários");

    public async Task<Response<User?>> GetByIdAsync(GetUsuarioByIdRequest request)
        => await _client.GetFromJsonAsync<Response<User?>>($"vi/usuario/{request.Id}")
            ?? new Response<User?>(null, 400, "Não foi possível obter o usuário");

    public async Task<Response<User?>> UpdateAsync(UpdateUsuarioRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/usuario/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<User?>>()
            ?? new Response<User?>(null, 400, "Falha ao atualizar usuário");
    }
}
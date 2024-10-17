using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cliente;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Clientes;

public class CreateClienteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Clientes: Create")
            .WithSummary("Cria um novo cliente")
            .WithDescription("Cria um novo cliente")
            .WithOrder(1)
            .Produces<Response<Cliente?>>();

    private static async Task<IResult> HandleAsync(
        IClienteHandler handler,
        CreateClienteRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
        var response = await handler.CreateAsync(request);
        return response.IsSuccess
            ? TypedResults.Created($"v1/cliente/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}

using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cliente;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Cliente;

public class GetClienteByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Clientes: Get By Id")
            .WithSummary("Recupera um Cliente")
            .WithDescription("Recupera um Cliente")
            .WithOrder(4)
            .Produces<Response<Cliente?>>();

    private static async Task<IResult> HandleAsync(
        IClienteHandler handler,
        Guid id)
    {
        var request = new GetClienteByIdRequest
        {
            UserId = ApiConfiguration.UserId,
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Clientes;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Clientes;

public class DeleteClienteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
       => app.MapDelete("/{id}", HandleAsync)
           .WithName("Clientes: Delete")
           .WithSummary("Exclui um Cliente")
           .WithDescription("Exclui um Cliente")
           .WithOrder(3)
           .Produces<Response<Cliente?>>();

    private static async Task<IResult> HandleAsync(
        IClienteHandler handler,
        Guid id)
    {
        var request = new DeleteClienteRequest
        {
            UserId = ApiConfiguration.UserId,
            Id = id
        };

        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

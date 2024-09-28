using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Estados;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Estados;

public class DeleteEstadoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
       => app.MapDelete("/{id}", HandleAsync)
           .WithName("Estados: Delete")
           .WithSummary("Exclui um Estado")
           .WithDescription("Exclui um Estado")
           .WithOrder(3)
           .Produces<Response<Estado?>>();

    private static async Task<IResult> HandleAsync(
        IEstadoHandler handler,
        Guid id)
    {
        var request = new DeleteEstadoRequest
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

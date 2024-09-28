using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Estados;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Estados;

public class GetEstadoByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/{id}", HandleAsync)
        .WithName("Estados: Get By Id")
        .WithSummary("Recupera um Estado")
        .WithDescription("Recupera um Estado")
        .WithOrder(4)
        .Produces<Response<Estado?>>();

    private static async Task<IResult> HandleAsync(
        IEstadoHandler handler,
        Guid id)
    {
        var request = new GetEstadoByIdRequest
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

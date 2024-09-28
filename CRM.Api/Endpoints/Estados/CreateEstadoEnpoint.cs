using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Estados;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Estados;

public class CreateEstadoEnpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Estados: Create")
            .WithSummary("Cria uma nova Estado")
            .WithDescription("Cria uma nova Estado")
            .WithOrder(1)
            .Produces<Response<Estado?>>();

    private static async Task<IResult> HandleAsync(
        IEstadoHandler handler,
        CreateEstadoRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
        var response = await handler.CreateAsync(request);
        return response.IsSuccess
            ? TypedResults.Created($"v1/Estados/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}

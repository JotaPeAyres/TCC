using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cidades;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Cidades;

public class CreateCidadeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Cidades: Create")
            .WithSummary("Cria uma nova cidade")
            .WithDescription("Cria uma nova cidade")
            .WithOrder(1)
            .Produces<Response<Cidade?>>();

    private static async Task<IResult> HandleAsync(
        ICidadeHandler handler,
        CreateCidadeRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
        var response = await handler.CreateAsync(request);
        return response.IsSuccess
            ? TypedResults.Created($"v1/cidades/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}

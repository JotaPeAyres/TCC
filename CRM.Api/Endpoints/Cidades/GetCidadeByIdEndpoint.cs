using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cidades;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Cidades;

public class GetCidadeByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Cidades: Get By Id")
            .WithSummary("Recupera uma cidade")
            .WithDescription("Recupera uma cidade")
            .WithOrder(4)
            .Produces<Response<Cidade?>>();

    private static async Task<IResult> HandleAsync(
        ICidadeHandler handler,
        Guid id)
    {
        var request = new GetCidadeByIdRequest
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

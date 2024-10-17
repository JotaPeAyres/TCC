using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cidades;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Cidades;

public class UpdateCidadeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Cidades: Update")
            .WithSummary("Atualiza uma cidade")
            .WithDescription("Atualiza uma cidade")
            .WithOrder(2)
            .Produces<Response<Cidade?>>();

    private static async Task<IResult> HandleAsync(
        ICidadeHandler handler,
        UpdateCidadeRequest request,
        Guid id)
    {
        request.UserId = ApiConfiguration.UserId;
        request.Id = id;

        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

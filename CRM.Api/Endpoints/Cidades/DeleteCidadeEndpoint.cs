using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cidades;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Cidades;

public class DeleteCidadeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
       => app.MapDelete("/{id}", HandleAsync)
           .WithName("Cidades: Delete")
           .WithSummary("Exclui uma cidade")
           .WithDescription("Exclui uma cidade")
           .WithOrder(3)
           .Produces<Response<Cidade?>>();

    private static async Task<IResult> HandleAsync(
        ICidadeHandler handler,
        Guid id)
    {
        var request = new DeleteCidadeRequest
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

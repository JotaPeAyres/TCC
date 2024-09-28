using CRM.Core.Responses;
using CRM.Core;
using Microsoft.AspNetCore.Mvc;
using CRM.Core.Models;
using CRM.Core.Handlers;
using CRM.Core.Requests.Cidades;
using CRM.Api.Common.Api;

namespace CRM.Api.Endpoints.Cidades;

public class GetAllCidadesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Cidades: Get All")
            .WithSummary("Recupera todas as cidades")
            .WithDescription("Recupera todas as cidades")
            .WithOrder(5)
            .Produces<PagedResponse<List<Cidade>?>>();

    private static async Task<IResult> HandleAsync(
        ICidadeHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCidadesRequest
        {
            UserId = ApiConfiguration.UserId,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };

        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

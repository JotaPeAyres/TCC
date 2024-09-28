using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Estados;
using CRM.Core.Responses;
using CRM.Core;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Endpoints.Estados;

public class GetAllEstadosEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
       => app.MapGet("/", HandleAsync)
           .WithName("Estados: Get All")
           .WithSummary("Recupera todos os estados")
           .WithDescription("Recupera todos os estados")
           .WithOrder(5)
           .Produces<PagedResponse<List<Estado>?>>();

    private static async Task<IResult> HandleAsync(
        IEstadoHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllEstadosRequest
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

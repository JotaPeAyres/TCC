using CRM.Core.Responses;
using CRM.Core;
using Microsoft.AspNetCore.Mvc;
using CRM.Core.Models;
using CRM.Core.Handlers;
using CRM.Core.Requests.Clientes;
using CRM.Api.Common.Api;

namespace CRM.Api.Endpoints.Clientes;

public class GetAllClienteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Clientes: Get All")
            .WithSummary("Recupera todos os Clientes")
            .WithDescription("Recupera todos os Clientes")
            .WithOrder(5)
            .Produces<PagedResponse<List<Cliente>?>>();

    private static async Task<IResult> HandleAsync(
        ICidadeHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllClienteRequest
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

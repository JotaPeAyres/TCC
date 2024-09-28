using CRM.Api.Common.Api;
using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Estados;
using CRM.Core.Responses;

namespace CRM.Api.Endpoints.Estados
{
    public class UpdateEstadoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Estados: Update")
            .WithSummary("Atualiza um Estado")
            .WithDescription("Atualiza um Estado")
            .WithOrder(2)
            .Produces<Response<Estado?>>();

        private static async Task<IResult> HandleAsync(
            IEstadoHandler handler,
            UpdateEstadoRequest request,
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
}

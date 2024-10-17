using CRM.Api.Common.Api;
using CRM.Api.Endpoints.Cidades;
using CRM.Api.Endpoints.Estados;
using CRM.Core.Requests.Cidades;

namespace CRM.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

        endpoints.MapGroup("v1/cidades")
            .WithTags("Cidades")
            .MapEndpoint<CreateClienteEndpoint>()
            .MapEndpoint<UpdateCidadeEndpoint>()
            .MapEndpoint<DeleteCidadeEndpoint>()
            .MapEndpoint<GetCidadeByIdEndpoint>()
            .MapEndpoint<GetAllCidadesEndpoint>();

        endpoints.MapGroup("v1/Estados")
            .WithTags("Estados")
            .RequireAuthorization()
            .MapEndpoint<CreateEstadoEnpoint>()
            .MapEndpoint<UpdateEstadoEndpoint>()
            .MapEndpoint<DeleteEstadoEndpoint>()
            .MapEndpoint<GetEstadoByIdEndpoint>()
            .MapEndpoint<GetAllEstadosEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}

using CRM.Core.Models;
using CRM.Core.Requests.Pedido;
using CRM.Core.Responses;

namespace CRM.Core.Handlers
{
    public interface IPedidoHandler
    {
        Task<Response<Pedido?>> CreateAsync(CreatePedidoRequest request);
        Task<Response<Pedido?>> UpdateAsync(UpdatePedidoRequest request);
        Task<Response<Pedido?>> DeleteAsync(DeletePedidoRequest request);
        Task<Response<Pedido?>> GetByIdAsync(GetPedidoByIdRequest request);
        Task<PagedResponse<List<Pedido>?>> GetAllAsync(GetAllPedidoRequest request);
    }
}

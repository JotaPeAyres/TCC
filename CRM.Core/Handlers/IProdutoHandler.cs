using CRM.Core.Models;
using CRM.Core.Requests.Produto;
using CRM.Core.Responses;

namespace CRM.Core.Handlers
{
    public interface IProdutoHandler
    {
        Task<Response<Produto?>> CreateAsync(CreateProdutoRequest request);
        Task<Response<Produto?>> UpdateAsync(UpdateProdutoRequest request);
        Task<Response<Produto?>> DeleteAsync(DeleteProdutoRequest request);
        Task<Response<Produto?>> GetByIdAsync(GetProdutoByIdRequest request);
        Task<PagedResponse<List<Produto>?>> GetAllAsync(GetAllProdutosRequest request);
    }
}

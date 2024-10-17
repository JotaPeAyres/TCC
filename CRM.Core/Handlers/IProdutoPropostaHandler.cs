using CRM.Core.Models;
using CRM.Core.Responses;
using CRM.Core.Requests.ProdutoProposta;

namespace CRM.Core.Handlers
{
    public interface IProdutoPropostaHandler
    {
        Task<Response<ProdutoProposta?>> CreateAsync(CreateProdutoPropostaRequest request);
        Task<Response<ProdutoProposta?>> UpdateAsync(UpdateProdutoPropostaRequest request);
        Task<Response<ProdutoProposta?>> DeleteAsync(DeleteProdutoPropostaRequest request);
        Task<Response<ProdutoProposta?>> GetByIdAsync(GetProdutoPropostaByIdRequest request);
        Task<PagedResponse<List<ProdutoProposta>?>> GetAllAsync(GetAllProdutoPropostaRequest request);
    }
}

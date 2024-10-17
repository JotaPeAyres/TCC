using CRM.Core.Models;
using CRM.Core.Requests.Usuario;
using CRM.Core.Responses;

namespace CRM.Core.Handlers
{
    public interface IUsuarioHandler
    {
        Task<Response<Usuario?>> CreateAsync(CreateUsuarioRequest request);
        Task<Response<Usuario?>> UpdateAsync(UpdateUsuarioRequest request);
        Task<Response<Usuario?>> DeleteAsync(DeleteUsuarioRequest request);
        Task<Response<Usuario?>> GetByIdAsync(GetUsuarioByIdRequest request);
        Task<PagedResponse<List<Usuario>?>> GetAllAsync(GetAllUsuariosRequest request);
    }
}

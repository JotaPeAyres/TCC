using CRM.Core.Models;
using CRM.Core.Requests.Usuario;
using CRM.Core.Responses;

namespace CRM.Core.Handlers
{
    public interface IUsuarioHandler
    {
        Task<Response<User?>> CreateAsync(CreateUsuarioRequest request);
        Task<Response<User?>> UpdateAsync(UpdateUsuarioRequest request);
        Task<Response<User?>> DeleteAsync(DeleteUsuarioRequest request);
        Task<Response<User?>> GetByIdAsync(GetUsuarioByIdRequest request);
        Task<PagedResponse<List<User>?>> GetAllAsync(GetAllUsuariosRequest request);
    }
}

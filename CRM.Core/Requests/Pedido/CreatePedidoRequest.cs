using System.ComponentModel.DataAnnotations;

namespace CRM.Core.Requests.Pedido
{
    public class CreatePedidoRequest : Request
    {
        [Required(ErrorMessage = "Título inválido")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição inválida")]
        public string Descricao { get; set; } = string.Empty;
    }
}

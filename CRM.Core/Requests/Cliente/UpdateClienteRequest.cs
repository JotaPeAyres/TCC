using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Requests.Cliente
{
    public class UpdateClienteRequest : Request
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Razão Social inválida")]
        [MaxLength(100, ErrorMessage = "A Razão Social deve conter até 100 caracteres")]
        public string RazaoSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nome Fantasia inválido")]
        [MaxLength(100, ErrorMessage = "O Nome Fantasia deve conter até 100 caracteres")]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required(ErrorMessage = "Documento inválido")]
        [MaxLength(14, ErrorMessage = "A Documento deve conter até 14 caracteres")]
        public string Documento { get; set; } = string.Empty;

        [Required(ErrorMessage = "Documento inválido")]
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "Documento inválido")]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "Estado inválido")]
        public Guid EstadoId { get; set; }

        [Required(ErrorMessage = "Cidade inválida")]
        public Guid CidadeId { get; set; }

        [Required(ErrorMessage = "Data inclusão inválida")]
        public DateTime? DataInclusao { get; set; }

        [Required(ErrorMessage = "Usuário inválido")]
        public Guid UsuarioId { get; set; }
    }
}

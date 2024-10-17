using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Requests.Cidades;

public class CreateCidadeRequest : Request
{
    [Required(ErrorMessage = "Nome inválido")]
    [MaxLength(100, ErrorMessage = "O nome deve conter até 100 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Estado inválido")]
    public Guid EstadoId { get; set; }

    [Required(ErrorMessage = "Data inclusão inválida")]
    public DateTime? DataInclusao { get; set; }

    [Required(ErrorMessage = "Usuário inválido")]
    public Guid UsuarioId { get; set; }
}

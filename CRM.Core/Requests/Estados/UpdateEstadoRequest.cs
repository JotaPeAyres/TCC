using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Requests.Estados;

public class UpdateEstadoRequest : Request
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Nome inválido")]
    [MaxLength(100, ErrorMessage = "O nome deve conter até 100 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Sigla inválida")]
    public string SiglaEstado { get; set; } = string.Empty;
}

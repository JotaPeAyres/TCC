using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Core.Models;

public class Estado
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public DateTime DataInclusao { get; set; }

    public string SiglaEstado { get; set; } = string.Empty;

    [ForeignKey("usuarioInclusao")]
    public Guid usuarioInclusaoId { get; set; }
    public virtual User UsuarioInclusao { get; set; }
}

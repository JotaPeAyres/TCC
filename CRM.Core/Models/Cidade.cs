using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models;

public class Cidade
{

    public Guid Id { get; set; }

    public DateTime DataInclusao { get; set; }
    public string Nome { get; set; } = string.Empty;

    [ForeignKey("Estado")]
    public Guid EstadoId { get; set; }
    public virtual Estado Estado { get; set; }

    [ForeignKey("UsuarioInclusao")]
    public Guid UsuarioInclusaoId { get; set; }
    public virtual User UsuarioInclusao { get; set; } 
}

using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Core.Models
{
    public class Tarefa
    {

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual User UsuarioInclusao { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime DataTarefa { get; set; }
    }
}

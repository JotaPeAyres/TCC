using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Core.Models
{
    public class Proposta
    {

        public Guid Id { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual User UsuarioInclusao { get; set; }

        [ForeignKey("StatusProposta")]
        public Guid statusPropostaId { get; set; }
        public virtual StatusProposta StatusProposta { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}

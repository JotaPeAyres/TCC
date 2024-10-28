using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class ProdutoProposta
    {
        public Guid Id { get; set; }

        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInclusao { get; set; }

        [ForeignKey("usuarioInclusao")]
        public Guid usuarioInclusaoId { get; set; }
        public virtual User UsuarioInclusao { get; set; }

        [ForeignKey("Proposta")]
        public Guid PropostaId { get; set; }
        public virtual Proposta Proposta { get; set; }

        [ForeignKey("Produto")]
        public Guid ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}

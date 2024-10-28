using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Requests.Agenda
{
    public class UpdateAgendaRequest : Request
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Título inválido")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição inválida")]
        public string Descricao { get; set; } = string.Empty;

        public DateTime DataInclusao { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CRM.Core.Requests.Tarefa
{
    public class UpdateTarefaRequest : Request
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Título inválido")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição inválida")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data da Tarefa inválida")]
        public DateTime DataTarefa { get; set; }
    }
}

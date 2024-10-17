using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cidades;
using CRM.Core.Requests.Estados;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CRM.Web.Pages.Cidades;

public partial class ListCidadesPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public List<Cidade> Cidades { get; set; } = [];
    public string SearchTerm { get; set; } = string.Empty;

    #endregion

    #region Services

    [Inject]
    public ICidadeHandler Handler { get; set; } = null!;

    [Inject]
    public IDialogService Dialog { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllCidadesRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Cidades = result.Data ?? [];
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally { IsBusy = false; }
    }

    #endregion

    #region Methods

    public async void OnDeleteButtonClickedAsync(Guid id, string title)
    {
        var result = await Dialog.ShowMessageBox(
            "ATENÇÃO",
            $"Ao prosseguir a cidade {title} será removida. Deseja continuar?",
            yesText: "Excluir",
            cancelText: "Cancelar");

        if (result is true)
            await OnDeleteAsync(id, title);

        StateHasChanged();
    }

    public async Task OnDeleteAsync(Guid id, string title)
    {
        try
        {
            var request = new DeleteCidadeRequest
            {
                Id = id
            };
            await Handler.DeleteAsync(request);
            Cidades.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Cidade {title} removida", Severity.Info);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    public Func<Cidade, bool> Filter => category =>
    {
        if (string.IsNullOrWhiteSpace(SearchTerm))
            return true;

        if (category.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (category.Nome.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (category.Estado.SiglaEstado is not null &&
            category.Estado.SiglaEstado.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };

    #endregion
}

using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Cidades;
using CRM.Core.Requests.Cliente;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CRM.Web.Pages.Clientes;

public partial class ListClientePage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public List<Cliente> Clientes { get; set; } = [];
    public string SearchTerm { get; set; } = string.Empty;

    #endregion

    #region Services

    [Inject]
    public IClienteHandler Handler { get; set; } = null!;

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
            var request = new GetAllClientesRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Clientes = result.Data ?? [];
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
            $"Ao prosseguir o cliente {title} será removido. Deseja continuar?",
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
            var request = new DeleteClienteRequest { /*Id = id*/ };
            await Handler.DeleteAsync(request);
            Clientes.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Cliente {title} removido", Severity.Info);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

    public Func<Cliente, bool> Filter => category =>
    {
        if (string.IsNullOrWhiteSpace(SearchTerm))
            return true;

        if (category.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (category.RazaoSocial.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (category.Documento.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (category.NomeFantasia.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };

    #endregion
}

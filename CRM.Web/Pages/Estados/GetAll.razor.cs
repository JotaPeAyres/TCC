﻿using CRM.Core.Handlers;
using CRM.Core.Models;
using CRM.Core.Requests.Estados;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CRM.Web.Pages.Estados;

public partial class GetAllEstadosPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public List<Estado> Estados { get; set; } = [];

    #endregion

    #region Services

    [Inject]
    public IEstadoHandler Handler { get; set; } = null!;

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
            var request = new GetAllEstadosRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Estados = result.Data ?? [];
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally { IsBusy = false; }
    }

    #endregion

    public async void OnDeleteButtonClickedAsync(Guid id, string title)
    {
        var result = await Dialog.ShowMessageBox(
            "ATENÇÃO",
            $"Ao prosseguir o estado {title} será removido. Deseja continuar?",
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
            var request = new DeleteEstadoRequest
            {
                Id = id
            };
            await Handler.DeleteAsync(request);
            Estados.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Estado {title} removido", Severity.Info);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
}

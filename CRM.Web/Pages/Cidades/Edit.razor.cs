﻿using CRM.Core.Handlers;
using CRM.Core.Requests.Cidades;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CRM.Web.Pages.Cidades;

public partial class EditCidadePage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public UpdateCidadeRequest InputModel { get; set; } = new();

    #endregion

    #region Parameters

    [Parameter]
    public string Id { get; set; } = string.Empty;

    #endregion

    #region Services

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ICidadeHandler Handler { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        GetCidadeByIdRequest? request = null;
        try
        {
            request = new GetCidadeByIdRequest
            {
                Id = Guid.Parse(Id)
            };
        }
        catch
        {
            Snackbar.Add("Parâmetro inválido", Severity.Error);
        }

        if (request is null)
            return;

        IsBusy = true;
        try
        {
            var response = await Handler.GetByIdAsync(request);
            if (response is { IsSuccess: true, Data: not null })
                InputModel = new UpdateCidadeRequest
                {
                    Id = response.Data.Id,
                    Nome = response.Data.Nome,
                    EstadoId = response.Data.EstadoId
                };
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.UpdateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add("Cidade atualizada", Severity.Success);
                NavigationManager.NavigateTo("/cidades");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion
}

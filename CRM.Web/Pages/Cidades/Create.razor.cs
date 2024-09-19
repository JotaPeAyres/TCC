using CRM.Core.Handlers;
using CRM.Core.Requests.Cidades;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Runtime.CompilerServices;

namespace CRM.Web.Pages.Cidades;

public partial class CreateCidadePage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public CreateCidadeRequest InputModel { get; set; } = new();

    #endregion

    #region Services

    [Inject]
    public ICidadeHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.CreateAsync(InputModel);
            if (result.IsSuccess) 
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/cidades");
            }
            else
                Snackbar.Add(result.Message, Severity.Error);
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
        finally { IsBusy = false; }
    }

    #endregion
}
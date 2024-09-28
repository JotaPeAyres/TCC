using CRM.Core.Handlers;
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

    #region Methods



    #endregion
}

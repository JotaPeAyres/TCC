using CRM.Core.Handlers;
using CRM.Core.Requests.Estados;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CRM.Web.Pages.Estados;

public partial class CreateEstadoPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public CreateEstadoRequest InputModel { get; set; } = new();

    public string[] Siglas =
    {
        "AC", "AL", "AP", "AM", "BA", "CE",
        "DF", "ES", "GO", "MA", "MT", "MS",
        "MG", "PA", "PB", "PR", "PE", "PI",
        "RJ", "RN", "RS", "RO", "RR", "SC",
        "SP", "SE", "TO"
    };

    #endregion

    #region Services

    [Inject]
    public IEstadoHandler Handler { get; set; } = null!;

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
                NavigationManager.NavigateTo("/estados");
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

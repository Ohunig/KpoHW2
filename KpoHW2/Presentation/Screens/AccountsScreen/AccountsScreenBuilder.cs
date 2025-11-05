using KpoHW2.Application.Facades;
using KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic;
using KpoHW2.Application.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace KpoHW2.Presentation.Screens.AccountsScreen;

/// <summary>
/// Билдер экрана
/// Находится в Presentation так как напрямую взаимодействует с объектами оттуда
/// </summary>
public static class AccountsScreenBuilder
{
    /// <summary>
    /// Собирает все объекты нужные для экрана
    /// </summary>
    /// <returns>Контроллер данного экрана</returns>
    public static AccountsScreenViewController Build()
    {
        AccountsScreenPresenter screenPresenter =
            new AccountsScreenPresenter(CompositionRoot.Services.GetRequiredService<NavigationController>());
        
        AccountsInteractor interactor = new AccountsInteractor(screenPresenter,
            CompositionRoot.Services.GetRequiredService<BankAccountFacade>());
        
        AccountsScreenViewController view = new AccountsScreenViewController(interactor,
            CompositionRoot.Services.GetRequiredService<IConsoleManager>());

        screenPresenter.view = new WeakReference<AccountsScreenViewController>(view);

        return view;
    }
}
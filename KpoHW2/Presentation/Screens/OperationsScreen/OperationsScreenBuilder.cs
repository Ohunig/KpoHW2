using KpoHW2.Application.Facades;
using KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic;
using KpoHW2.Application.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace KpoHW2.Presentation.Screens.OperationsScreen;

/// <summary>
/// Билдер экрана операций
/// </summary>
public static class OperationsScreenBuilder
{
    /// <summary>
    /// Собирает все объекты нужные для экрана
    /// </summary>
    /// <returns>Контроллер данного экрана</returns>
    public static OperationsScreenViewController Build()
    {
        OperationsScreenPresenter screenPresenter =
            new OperationsScreenPresenter(CompositionRoot.Services.GetRequiredService<NavigationController>());

        OperationsInteractor interactor = new OperationsInteractor(screenPresenter,
            CompositionRoot.Services.GetRequiredService<OperationFacade>());

        OperationsScreenViewController view = new OperationsScreenViewController(interactor,
            CompositionRoot.Services.GetRequiredService<IConsoleManager>());

        screenPresenter.view = new WeakReference<OperationsScreenViewController>(view);

        return view;
    }
}
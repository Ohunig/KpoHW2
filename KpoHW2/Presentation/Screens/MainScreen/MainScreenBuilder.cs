using KpoHW2.Application.Interactions.MainScreen;
using KpoHW2.Application.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace KpoHW2.Presentation.MainScreen;

/// <summary>
/// Билдер экрана
/// Находится в Presentation так как напрямую взаимодействует с объектами оттуда
/// </summary>
public static class MainScreenBuilder
{
    /// <summary>
    /// Собирает все объекты нужные для экрана
    /// </summary>
    /// <returns>Контроллер данного экрана</returns>
    public static MainScreenViewController Build()
    {
        MainScreenPresenter screenPresenter =
            new MainScreenPresenter(CompositionRoot.Services.GetRequiredService<NavigationController>());
        MainInteractor interactor = new MainInteractor(screenPresenter);
        MainScreenViewController view = new MainScreenViewController(interactor,
            CompositionRoot.Services.GetRequiredService<IConsoleManager>());

        screenPresenter.view = new WeakReference<MainScreenViewController>(view);

        return view;
    }
}
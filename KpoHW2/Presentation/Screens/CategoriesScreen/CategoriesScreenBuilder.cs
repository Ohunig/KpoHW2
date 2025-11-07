using KpoHW2.Application.Facades;
using KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic;
using KpoHW2.Application.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace KpoHW2.Presentation.Screens.CategoriesScreen;

/// <summary>
/// Билдер экрана категорий
/// </summary>
public static class CategoriesScreenBuilder
{
    /// <summary>
    /// Собирает все объекты нужные для экрана
    /// </summary>
    /// <returns>Контроллер данного экрана</returns>
    public static CategoriesScreenViewController Build()
    {
        CategoriesScreenPresenter screenPresenter =
            new CategoriesScreenPresenter(CompositionRoot.Services.GetRequiredService<NavigationController>());
        
        CategoriesInteractor interactor = new CategoriesInteractor(screenPresenter,
            CompositionRoot.Services.GetRequiredService<CategoryFacade>());
        
        CategoriesScreenViewController view = new CategoriesScreenViewController(interactor,
            CompositionRoot.Services.GetRequiredService<IConsoleManager>());

        screenPresenter.view = new WeakReference<CategoriesScreenViewController>(view);

        return view;
    }
}
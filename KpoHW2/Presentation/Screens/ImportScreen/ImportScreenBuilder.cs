using Microsoft.Extensions.DependencyInjection;
using KpoHW2.Application.Facades;
using KpoHW2.Application.Interactions.ImportLogic;
using KpoHW2.Application.Ports;

namespace KpoHW2.Presentation.Screens.ImportScreen;

public static class ImportScreenBuilder
{
    public static ImportScreenViewController Build()
    {
        var presenter = new ImportScreenPresenter(CompositionRoot.Services.GetRequiredService<NavigationController>());

        var interactor = new ImportInteractor(
            presenter,
            CompositionRoot.Services,
            CompositionRoot.Services.GetRequiredService<BankAccountFacade>(),
            CompositionRoot.Services.GetRequiredService<CategoryFacade>(),
            CompositionRoot.Services.GetRequiredService<OperationFacade>());

        var view = new ImportScreenViewController(interactor,
            CompositionRoot.Services.GetRequiredService<IConsoleManager>());

        presenter.view = new WeakReference<ImportScreenViewController>(view);

        return view;
    }
}
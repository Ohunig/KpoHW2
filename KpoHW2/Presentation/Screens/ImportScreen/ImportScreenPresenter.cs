using System;
using KpoHW2.Application.Interactions.ImportLogic.Interfaces;
using KpoHW2.Presentation.Screens.ImportScreen;

namespace KpoHW2.Presentation.Screens.ImportScreen;

public class ImportScreenPresenter(
    NavigationController navigationController)
    : Presenter(navigationController), IImportPresenter
{
    public WeakReference<ImportScreenViewController> view;

    public void ToStart()
    {
        navigationController.ToStart();
    }

    public void PresentImportResult(string message)
    {
        if (view != null && view.TryGetTarget(out var ctrl))
        {
            ctrl.ShowResult(message);
        }
    }
}
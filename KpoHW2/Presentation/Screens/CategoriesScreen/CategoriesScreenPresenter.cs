using KpoHW2.Application.Interactions.CategoriesLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic.CategoriesModel;

namespace KpoHW2.Presentation.Screens.CategoriesScreen;

public class CategoriesScreenPresenter(NavigationController navigationController)
    : Presenter(navigationController), ICategoriesPresenter
{
    public WeakReference<CategoriesScreenViewController> view;

    public void ToStart(Model.EndAction.Response response)
    {
        navigationController.ToStart();
    }

    public void PresentCommand(Model.GettingCommand.Response response)
    {
        CategoriesScreenViewController? viewController;
        view.TryGetTarget(out viewController);
        if (viewController != null)
        {
            var command = new TimerDecorator(response.Command);
            viewController.SetCommand(new Model.GettingCommand.ViewModel(command));
        }
    }
}
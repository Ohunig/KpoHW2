using KpoHW2.Application.Interactions.OperationsLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic.OperationsModel;

namespace KpoHW2.Presentation.Screens.OperationsScreen;

public class OperationsScreenPresenter(NavigationController navigationController)
    : Presenter(navigationController), IOperationsPresenter
{
    public WeakReference<OperationsScreenViewController> view;

    public void ToStart(Model.EndAction.Response response)
    {
        navigationController.ToStart();
    }

    public void PresentCommand(Model.GettingCommand.Response response)
    {
        OperationsScreenViewController? viewController;
        view.TryGetTarget(out viewController);
        if (viewController != null)
        {
            var command = new TimerDecorator(response.Command);
            viewController.SetCommand(new Model.GettingCommand.ViewModel(command));
        }
    }
}
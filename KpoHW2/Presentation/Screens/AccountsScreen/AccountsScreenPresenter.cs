using KpoHW2.Application.Interactions.AccountsLogic.Commands.Decorators;
using KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic;
using KpoHW2.Application.Interactions.AccountsLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic.AccountsModel;

namespace KpoHW2.Presentation.Screens.AccountsScreen;

public class AccountsScreenPresenter(NavigationController navigationController)
    : Presenter(navigationController), IAccountsPresenter
{
    public WeakReference<AccountsScreenViewController> view;

    public void ToStart(AccountsModel.EndAction.Response response)
    {
        navigationController.ToStart();
    }

    public void PresentCommand(AccountsModel.GettingCommand.Response response)
    {
        AccountsScreenViewController? viewController;
        view.TryGetTarget(out viewController);
        if (viewController != null)
        {
            var command = new TimerDecorator(response.Command);
            viewController.SetCommand(new Model.GettingCommand.ViewModel(command));
        }
    }
}
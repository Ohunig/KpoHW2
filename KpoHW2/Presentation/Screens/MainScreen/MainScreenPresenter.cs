using KpoHW2.Application.Interactions.MainScreen;
using KpoHW2.Presentation.Screens.AccountsScreen;

namespace KpoHW2.Presentation.MainScreen;

public class MainScreenPresenter(NavigationController navigationController)
    : Presenter(navigationController), IMainPresenter
{
    public WeakReference<MainScreenViewController> view;

    public void PresentNextScreen(MainModel.NextScreen.Response response)
    {
        switch (response)
        {
            case MainModel.NextScreen.Response.AccountsSelected:
                navigationController.Push(AccountsScreenBuilder.Build());
                break;
            case MainModel.NextScreen.Response.CategoriesSelected:
                break;
            case MainModel.NextScreen.Response.OperationsSelected:
                break;
        }
    }
}
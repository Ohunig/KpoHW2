using KpoHW2.Application.Interactions.MainScreen;
using KpoHW2.Presentation.Screens.AccountsScreen;
using KpoHW2.Presentation.Screens.CategoriesScreen;
using KpoHW2.Presentation.Screens.ImportScreen;
using KpoHW2.Presentation.Screens.OperationsScreen;

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
                navigationController.Push(CategoriesScreenBuilder.Build());
                break;
            case MainModel.NextScreen.Response.OperationsSelected:
                navigationController.Push(OperationsScreenBuilder.Build());
                break;
            case MainModel.NextScreen.Response.ImportSelected:
                navigationController.Push(ImportScreenBuilder.Build());
                break;
        }
    }
}
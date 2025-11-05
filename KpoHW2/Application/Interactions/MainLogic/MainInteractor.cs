namespace KpoHW2.Application.Interactions.MainScreen;

public class MainInteractor : IMainInteractor
{
    private IMainPresenter presenter;

    public MainInteractor(IMainPresenter presenter)
    {
        this.presenter = presenter;
    }

    public void LoadNextScreen(MainModel.NextScreen.Request request)
    {
        switch (request.Index)
        {
            case 1:
                presenter.PresentNextScreen(MainModel.NextScreen.Response.AccountsSelected);
                break;
            case 2:
                presenter.PresentNextScreen(MainModel.NextScreen.Response.CategoriesSelected);
                break;
            case 3:
                presenter.PresentNextScreen(MainModel.NextScreen.Response.OperationsSelected);
                break;
        }
    }
}
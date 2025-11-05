namespace KpoHW2.Application.Interactions.MainScreen;

public interface IMainPresenter
{
    public void PresentNextScreen(MainModel.NextScreen.Response response);
}
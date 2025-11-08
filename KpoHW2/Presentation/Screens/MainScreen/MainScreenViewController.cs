using System.Text;
using KpoHW2.Application.Interactions.MainScreen;
using KpoHW2.Application.Ports;

namespace KpoHW2.Presentation.MainScreen;

public class MainScreenViewController : ViewController
{
    private class Constants
    {
        public static string NextScreenError = "The wrong one is selected";
    }

    private IMainInteractor mainInteractor;

    public MainScreenViewController(IMainInteractor mainInteractor, IConsoleManager consoleManager) : base(
        consoleManager)
    {
        this.mainInteractor = mainInteractor;
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        ConfigureUI();
        HandleUserAction();
    }

    private void ConfigureUI()
    {
        StringBuilder message = new StringBuilder();
        message.AppendLine("Main Menu");
        message.AppendLine("1. Working with accounts");
        message.AppendLine("2. Working with categories");
        message.AppendLine("3. Working with operations");
        message.AppendLine("4. Import");
        Console.WriteLine(message.ToString());
    }

    public override void HandleUserAction()
    {
        int? number = consoleManager.GetIntResponse("Choose number: ");
        if (number == null || number.Value < 1 || number.Value > 4)
        {
            NextScreenAttemptError();
        }
        else
        {
            mainInteractor.LoadNextScreen(new MainModel.NextScreen.Request(number.Value));
        }
    }

    private void NextScreenAttemptError()
    {
        consoleManager.PrintError(Constants.NextScreenError);
        consoleManager.WaitButtonPress();
        ViewDidLoad();
    }
}
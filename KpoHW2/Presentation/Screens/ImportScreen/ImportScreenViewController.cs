using System.Text;
using KpoHW2.Application.Import;
using KpoHW2.Application.Interactions.ImportLogic.Interfaces;
using KpoHW2.Application.Ports;

namespace KpoHW2.Presentation.Screens.ImportScreen;

public class ImportScreenViewController : ViewController
{
    private class Constants
    {
        public static string ChoiceError = "The wrong one is selected";
    }
    
    private readonly IImportInteractor _interactor;
    private string _lastResult = string.Empty;

    public ImportScreenViewController(IImportInteractor interactor, IConsoleManager consoleManager) : base(
        consoleManager)
    {
        _interactor = interactor;
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        ConfigureUI();
        HandleUserAction();
    }

    public void ConfigureUI()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Import Menu");
        sb.AppendLine("1. Import accounts");
        sb.AppendLine("2. Import categories");
        sb.AppendLine("3. Import operations");
        Console.Clear();
        consoleManager.Print(sb.ToString());
    }

    public override void HandleUserAction()
    {
        int? choice = consoleManager.GetIntResponse("Choose number: ");
        Console.Clear();
        switch (choice)
        {
            case 1:
                HandleImportAccounts();
                break;
            case 2:
                HandleImportCategories();
                break;
            case 3:
                HandleImportOperations();
                break;
            default:
                ChoiceError();
                break;
        }
    }

    private ImportFormat AskFormat()
    {
        while (true)
        {
            var f = consoleManager.GetStringResponse("Format (json/csv): ");
            if (string.Equals(f, "json", StringComparison.OrdinalIgnoreCase)) return ImportFormat.Json;
            if (string.Equals(f, "csv", StringComparison.OrdinalIgnoreCase)) return ImportFormat.Csv;
            consoleManager.Print("Unknown format. Type 'json' or 'csv'.");
        }
    }

    private void HandleImportAccounts()
    {
        var format = AskFormat();
        var path = consoleManager.GetStringResponse("Write file path: ");
        _interactor.ImportAccounts(format, path);
        WaitAndShow();
    }

    private void HandleImportCategories()
    {
        var format = AskFormat();
        var path = consoleManager.GetStringResponse("Write file path: ");
        _interactor.ImportCategories(format, path);
        WaitAndShow();
    }

    private void HandleImportOperations()
    {
        var format = AskFormat();
        var path = consoleManager.GetStringResponse("Write file path: ");
        _interactor.ImportOperations(format, path);
        WaitAndShow();
    }

    // вызывается презентером
    public void ShowResult(string message) => _lastResult = message;

    private void WaitAndShow()
    {
        consoleManager.Print(_lastResult);
        consoleManager.WaitButtonPress();
        _interactor.ToStart();
    }
    
    private void ChoiceError()
    {
        consoleManager.PrintError(Constants.ChoiceError);
        consoleManager.WaitButtonPress();
        ViewDidLoad();
    }
}
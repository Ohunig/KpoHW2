using System.ComponentModel.Design;
using System.Text;
using KpoHW2.Application.Interactions.AccountsLogic.Commands;
using KpoHW2.Application.Interactions.AccountsLogic.Interfaces;
using KpoHW2.Application.Ports;
using Model = KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic.AccountsModel;

namespace KpoHW2.Presentation.Screens.AccountsScreen;

public class AccountsScreenViewController(IAccountsInteractor accountsInteractor, IConsoleManager consoleManager)
    : ViewController(consoleManager)
{
    private class Constants
    {
        public static string NextScreenError = "The wrong one is selected";
        
        public static string NoCommandError = "This is not command";
    }

    private IAccountsInteractor accountsInteractor = accountsInteractor;

    private ICommand? command = null;

    /// <summary>
    /// Установка исполняемой команды
    /// </summary>
    /// <param name="model">Модель содержащая команду</param>
    public void SetCommand(Model.GettingCommand.ViewModel model)
    {
        this.command = model.Command;
    }

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Отчёт</returns>
    private string ExecuteCommand()
    {
        if (command != null)
        {
            return command.Execute();
        }
        return Constants.NoCommandError;
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        ConfigureUI();
        HandleUserAction();
    }

    public void ConfigureUI()
    {
        StringBuilder message = new StringBuilder();
        message.AppendLine("1. Show accounts");
        message.AppendLine("2. Add new account");
        message.AppendLine("3. Update account");
        message.AppendLine("4. Delete account");
        consoleManager.Print(message.ToString());
    }
    
    public override void HandleUserAction()
    {
        int? response = consoleManager.GetIntResponse("Choose number: ");
        Console.Clear();
        switch (response)
        {
            case 1:
                ShowAccounts();
                break;
            case 2:
                HandleAddAccount();
                break;
            case 3:
                HandleUpdateAccount();
                break;
            case 4:
                HandleDeleteAccount();
                break;
            default:
                consoleManager.Print(Constants.NoCommandError);
                consoleManager.WaitButtonPress();
                accountsInteractor.ToStart(new Model.EndAction.Request());
                break;
        }
    }

    /// <summary>
    /// Показывает существующие аккаунты
    /// </summary>
    private void ShowAccounts()
    {
        accountsInteractor.GetCommand(new Model.GettingCommand.Request(1));
        ShowExecuteReport();
    }

    private void HandleAddAccount()
    {
        string? name = consoleManager.GetStringResponse("Write a name of account: ");
        accountsInteractor.GetCommand(new Model.GettingCommand.Request(2, null, name));
        ShowExecuteReport();
    }

    /// <summary>
    /// Обновляет аккаунт.
    /// </summary>
    private void HandleUpdateAccount()
    {
        int? id = consoleManager.GetIntResponse("Write an ID of account: ");
        string? name = consoleManager.GetStringResponse("Write new name: ");
        int? balance = consoleManager.GetIntResponse("Write new balance: ");
        accountsInteractor.GetCommand(new Model.GettingCommand.Request(3, id, name, balance));
        ShowExecuteReport();
    }

    private void HandleDeleteAccount()
    {
        int? id = consoleManager.GetIntResponse("Write an ID of account: ");
        accountsInteractor.GetCommand(new Model.GettingCommand.Request(4, id));
        ShowExecuteReport();
    }

    private void ShowExecuteReport()
    {
        consoleManager.Print(ExecuteCommand());
        consoleManager.WaitButtonPress();
        accountsInteractor.ToStart(new Model.EndAction.Request());
    }
}
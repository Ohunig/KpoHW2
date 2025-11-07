using System.ComponentModel.Design;
using System.Text;
using KpoHW2.Application.Interactions.OperationsLogic.Commands;
using KpoHW2.Application.Interactions.OperationsLogic.Interfaces;
using KpoHW2.Application.Ports;
using KpoHW2.Domain.Operation;
using Model = KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic.OperationsModel;

namespace KpoHW2.Presentation.Screens.OperationsScreen;

public class OperationsScreenViewController(IOperationsInteractor operationsInteractor, IConsoleManager consoleManager)
    : ViewController(consoleManager)
{
    private class Constants
    {
        public static string NextScreenError = "The wrong one is selected";

        public static string NoCommandError = "This is not command";
    }

    private IOperationsInteractor operationsInteractor = operationsInteractor;

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
        message.AppendLine("1. Show operations");
        message.AppendLine("2. Add new operation");
        message.AppendLine("3. Update operation (description)");
        message.AppendLine("4. Delete operation");
        consoleManager.Print(message.ToString());
    }

    public override void HandleUserAction()
    {
        int? response = consoleManager.GetIntResponse("Choose number: ");
        Console.Clear();
        switch (response)
        {
            case 1:
                ShowOperations();
                break;
            case 2:
                HandleAddOperation();
                break;
            case 3:
                HandleUpdateOperation();
                break;
            case 4:
                HandleDeleteOperation();
                break;
            default:
                consoleManager.Print(Constants.NoCommandError);
                consoleManager.WaitButtonPress();
                operationsInteractor.ToStart(new Model.EndAction.Request());
                break;
        }
    }

    /// <summary>
    /// Показывает существующие операции
    /// </summary>
    private void ShowOperations()
    {
        operationsInteractor.GetCommand(new Model.GettingCommand.Request(1));
        ShowExecuteReport();
    }

    private void HandleAddOperation()
    {
        int? typeInt = consoleManager.GetIntResponse("Write operation type (1: Income 2: Expenditure): ");
        OperationType? type = null;
        if (typeInt != null)
        {
            if (typeInt == 1)
                type = OperationType.Income;
            else if (typeInt == 2)
                type = OperationType.Expenditure;
        }
        int? accountId = consoleManager.GetIntResponse("Write a bank account ID: ");
        int? categoryId = consoleManager.GetIntResponse("Write a category ID: ");
        int? amount = consoleManager.GetIntResponse("Write amount: ");
        string? description = consoleManager.GetStringResponse("Write description (optional): ");

        operationsInteractor.GetCommand(new Model.GettingCommand.Request(2, null, type, accountId, categoryId, amount, description));
        ShowExecuteReport();
    }

    /// <summary>
    /// Обновляет операцию (только описание).
    /// </summary>
    private void HandleUpdateOperation()
    {
        int? id = consoleManager.GetIntResponse("Write an ID of operation: ");
        string? description = consoleManager.GetStringResponse("Write new description: ");
        operationsInteractor.GetCommand(new Model.GettingCommand.Request(3, id, null, null, null, null, description));
        ShowExecuteReport();
    }

    private void HandleDeleteOperation()
    {
        int? id = consoleManager.GetIntResponse("Write an ID of operation: ");
        operationsInteractor.GetCommand(new Model.GettingCommand.Request(4, id));
        ShowExecuteReport();
    }

    private void ShowExecuteReport()
    {
        consoleManager.Print(ExecuteCommand());
        consoleManager.WaitButtonPress();
        operationsInteractor.ToStart(new Model.EndAction.Request());
    }
}

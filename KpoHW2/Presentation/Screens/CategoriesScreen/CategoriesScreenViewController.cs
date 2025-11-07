using System.ComponentModel.Design;
using System.Text;
using KpoHW2.Application.Interactions.CategoriesLogic.Commands;
using KpoHW2.Application.Interactions.CategoriesLogic.Interfaces;
using KpoHW2.Application.Ports;
using KpoHW2.Domain.Category;
using Model = KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic.CategoriesModel;

namespace KpoHW2.Presentation.Screens.CategoriesScreen;

public class CategoriesScreenViewController(ICategoriesInteractor categoriesInteractor, IConsoleManager consoleManager)
    : ViewController(consoleManager)
{
    private class Constants
    {
        public static string NextScreenError = "The wrong one is selected";
        
        public static string NoCommandError = "This is not command";
    }

    private ICategoriesInteractor categoriesInteractor = categoriesInteractor;

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
        message.AppendLine("1. Show categories");
        message.AppendLine("2. Add new category");
        message.AppendLine("3. Update category");
        message.AppendLine("4. Delete category");
        consoleManager.Print(message.ToString());
    }
    
    public override void HandleUserAction()
    {
        int? response = consoleManager.GetIntResponse("Choose number: ");
        Console.Clear();
        switch (response)
        {
            case 1:
                ShowCategories();
                break;
            case 2:
                HandleAddCategory();
                break;
            case 3:
                HandleUpdateCategory();
                break;
            case 4:
                HandleDeleteCategory();
                break;
            default:
                consoleManager.Print(Constants.NoCommandError);
                consoleManager.WaitButtonPress();
                categoriesInteractor.ToStart(new Model.EndAction.Request());
                break;
        }
    }

    /// <summary>
    /// Показывает существующие категории
    /// </summary>
    private void ShowCategories()
    {
        categoriesInteractor.GetCommand(new Model.GettingCommand.Request(1));
        ShowExecuteReport();
    }

    private void HandleAddCategory()
    {
        string? name = consoleManager.GetStringResponse("Write a name of category: ");
        int? typeInt = consoleManager.GetIntResponse("Write a type of category (1: Income 2: Expenditure): ");
        CategoryType? type = null;
        if (typeInt != null)
        {
            if (typeInt.Value == 1) 
                type = CategoryType.Income;
            else if (typeInt.Value == 2)
                type = CategoryType.Expenditure;
        }
        categoriesInteractor.GetCommand(new Model.GettingCommand.Request(2, null, name, type));
        ShowExecuteReport();
    }

    /// <summary>
    /// Обновляет категорию.
    /// </summary>
    private void HandleUpdateCategory()
    {
        int? id = consoleManager.GetIntResponse("Write an ID of category: ");
        string? name = consoleManager.GetStringResponse("Write new name: ");
        categoriesInteractor.GetCommand(new Model.GettingCommand.Request(3, id, name));
        ShowExecuteReport();
    }

    private void HandleDeleteCategory()
    {
        int? id = consoleManager.GetIntResponse("Write an ID of category: ");
        categoriesInteractor.GetCommand(new Model.GettingCommand.Request(4, id));
        ShowExecuteReport();
    }

    private void ShowExecuteReport()
    {
        consoleManager.Print(ExecuteCommand());
        consoleManager.WaitButtonPress();
        categoriesInteractor.ToStart(new Model.EndAction.Request());
    }
}

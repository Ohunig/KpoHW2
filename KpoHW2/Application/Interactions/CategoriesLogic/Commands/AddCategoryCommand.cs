using KpoHW2.Application.Interactions.CategoriesLogic.Interfaces;
using KpoHW2.Domain.Category;
using Model = KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic.CategoriesModel;

public class AddCategoryCommand(ICategoriesInteractor receiver, string? name, CategoryType? categoryType) : ICommand
{
    public ICategoriesInteractor receiver = receiver;

    private string? name = name;
    private CategoryType? categoryType = categoryType;

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.AddCategory(new Model.GettingCommand.Request(null, null, name, categoryType));
    }
}
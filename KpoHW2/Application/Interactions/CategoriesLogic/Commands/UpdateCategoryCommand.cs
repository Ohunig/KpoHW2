using KpoHW2.Application.Interactions.CategoriesLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic.CategoriesModel;

public class UpdateCategoryCommand(ICategoriesInteractor receiver, int? id, string? name = null)
    : ICommand
{
    public ICategoriesInteractor receiver = receiver;

    private int? id = id;

    private string? name = name;

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.UpdateCategory(new Model.GettingCommand.Request(null, id, name));
    }
}
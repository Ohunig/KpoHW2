using KpoHW2.Application.Interactions.CategoriesLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic.CategoriesModel;

public class RemoveCategoryCommand(ICategoriesInteractor receiver, int? id) : ICommand
{
    public ICategoriesInteractor receiver = receiver;

    private int? id = id;
    
    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.RemoveCategory(new Model.GettingCommand.Request(null, id));
    }
}
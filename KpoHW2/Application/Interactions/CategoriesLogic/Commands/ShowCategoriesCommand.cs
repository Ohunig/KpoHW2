using KpoHW2.Application.Interactions.CategoriesLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic.CategoriesModel;

public class ShowCategoriesCommand(ICategoriesInteractor receiver) : ICommand
{
    public ICategoriesInteractor receiver = receiver;

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.GetCategories(new Model.GettingCommand.Request());
    }
}
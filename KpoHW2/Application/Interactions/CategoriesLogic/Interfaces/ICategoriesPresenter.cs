using Model = KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic.CategoriesModel;

namespace KpoHW2.Application.Interactions.CategoriesLogic.Interfaces;

/// <summary>
/// Презентер экрана категорий — декорирует команду и передаёт контроллеру
/// </summary>
public interface ICategoriesPresenter
{
    public void ToStart(Model.EndAction.Response response);
    
    public void PresentCommand(Model.GettingCommand.Response response);
}
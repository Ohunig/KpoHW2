using Model = KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic.CategoriesModel;

namespace KpoHW2.Application.Interactions.CategoriesLogic.Interfaces;

/// <summary>
/// Интерактор экрана категорий
/// </summary>
public interface ICategoriesInteractor
{
    public void ToStart(Model.EndAction.Request request);
    
    public void GetCommand(Model.GettingCommand.Request request);
    
    public string GetCategories(Model.GettingCommand.Request request);
    
    public string AddCategory(Model.GettingCommand.Request request);
    
    public string UpdateCategory(Model.GettingCommand.Request request);
    
    public string RemoveCategory(Model.GettingCommand.Request request);
}
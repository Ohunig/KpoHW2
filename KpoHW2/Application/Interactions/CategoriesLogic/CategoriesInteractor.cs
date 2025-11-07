using System.Text;
using KpoHW2.Application.Facades;
using KpoHW2.Application.Interactions.CategoriesLogic.Interfaces;
using KpoHW2.Domain.Category;
using Model = KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic.CategoriesModel;

namespace KpoHW2.Application.Interactions.CategoriesLogic.Commands.Interactions.CategoriesLogic;

/// <summary>
/// Интерактор экрана категорий
/// Отвечает за прикладную логику экрана
/// </summary>
/// <param name="presenter"></param>
/// <param name="categoryFacade"></param>
public class CategoriesInteractor(ICategoriesPresenter presenter, CategoryFacade categoryFacade) : ICategoriesInteractor
{
    private CategoryFacade categoryFacade = categoryFacade;

    private ICategoriesPresenter presenter = presenter;

    /// <summary>
    /// Подаёт сигнал презентеру вернуться на главный экран
    /// </summary>
    /// <param name="request">Запрос</param>
    public void ToStart(Model.EndAction.Request request)
    {
        presenter.ToStart(new Model.EndAction.Response());
    }

    /// <summary>
    /// Передаёт нужную команду презентеру
    /// </summary>
    /// <param name="request">Запрос от UI</param>
    public void GetCommand(Model.GettingCommand.Request request)
    {
        switch (request.Option)
        {
            case 1:
                var showCommand = new ShowCategoriesCommand(this);
                presenter.PresentCommand(new Model.GettingCommand.Response(showCommand));
                break;
            case 2:
                var addCommand = new AddCategoryCommand(this, request.Name, request.CategoryType);
                presenter.PresentCommand(new Model.GettingCommand.Response(addCommand));
                break;
            case 3:
                var updateCommand = new UpdateCategoryCommand(this, request.Id, request.Name);
                presenter.PresentCommand(new Model.GettingCommand.Response(updateCommand));
                break;
            case 4:
                var removeCommand = new RemoveCategoryCommand(this, request.Id);
                presenter.PresentCommand(new Model.GettingCommand.Response(removeCommand));
                break;
        }
    }

    /// <summary>
    /// Отдаёт отчёт со всеми категориями
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт с данными категорий</returns>
    public string GetCategories(Model.GettingCommand.Request request)
    {
        StringBuilder message = new StringBuilder();
        List<int> idList = categoryFacade.IdList.ToList();
        for (int i = 0; i < idList.Count; i++)
        {
            Category category = categoryFacade.GetCategory(idList[i]);
            message.AppendLine($"{category.Id}.\tName: {category.Name}\tType: {category.CategoryType}");
        }

        return message.ToString();
    }

    /// <summary>
    /// Добавляет новую категорию
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт</returns>
    public string AddCategory(Model.GettingCommand.Request request)
    {
        if (request.Name == null) return "Name is required";
        if (request.CategoryType == null) return "Category type is required";
        try
        {
            categoryFacade.CreateNewCategory(request.Name, request.CategoryType.Value);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return "Category created";
    }

    /// <summary>
    /// Изменяет существующую категорию
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт</returns>
    public string UpdateCategory(Model.GettingCommand.Request request)
    {
        if (request.Id == null || request.Name == null) return "Incorrect data";
        try
        {
            categoryFacade.ChangeCategory(request.Id.Value, request.Name);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return "Category updated";
    }

    /// <summary>
    /// Удаляет категорию
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт</returns>
    public string RemoveCategory(Model.GettingCommand.Request request)
    {
        if (request.Id == null) return "Id is required";
        try
        {
            categoryFacade.DeleteCategory(request.Id.Value);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return "Category deleted";
    }
}

using System.Text;
using KpoHW2.Application.Facades;
using KpoHW2.Application.Interactions.OperationsLogic.Interfaces;
using KpoHW2.Domain.Operation;
using Microsoft.Extensions.DependencyInjection;
using Model = KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic.OperationsModel;

namespace KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic;

/// <summary>
/// Интерактор экрана операций
/// Отвечает за прикладную логику экрана
/// </summary>
/// <param name="presenter"></param>
/// <param name="operationFacade"></param>
public class OperationsInteractor(IOperationsPresenter presenter, OperationFacade operationFacade) : IOperationsInteractor
{
    private OperationFacade operationFacade = operationFacade;

    private IOperationsPresenter presenter = presenter;

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
                var showCommand = new ShowOperationsCommand(this);
                presenter.PresentCommand(new Model.GettingCommand.Response(showCommand));
                break;
            case 2:
                var addCommand = new AddOperationCommand(this, request.Type, request.BankAccountId, request.CategoryId, request.Amount, request.Description);
                presenter.PresentCommand(new Model.GettingCommand.Response(addCommand));
                break;
            case 3:
                var updateCommand = new UpdateOperationCommand(this, request.Id, request.Description);
                presenter.PresentCommand(new Model.GettingCommand.Response(updateCommand));
                break;
            case 4:
                var removeCommand = new RemoveOperationCommand(this, request.Id);
                presenter.PresentCommand(new Model.GettingCommand.Response(removeCommand));
                break;
        }
    }

    /// <summary>
    /// Отдаёт отчёт со всеми операциями
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт с данными операций</returns>
    public string GetOperations(Model.GettingCommand.Request request)
    {
        StringBuilder message = new StringBuilder();
        List<int> idList = operationFacade.IdList.ToList();
        for (int i = 0; i < idList.Count; i++)
        {
            Operation operation = operationFacade.GetOperation(idList[i]);
            message.AppendLine($"{operation.Id}.\nType: {operation.Type}\nAccountId: {operation.BankAccountId}\nCategoryId: {operation.CategoryId}\nAmount: {operation.Amount}\nDate: {operation.Date}\nDescription: {operation.Description}\n");
        }

        return message.ToString();
    }

    /// <summary>
    /// Добавляет новую операцию
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт</returns>
    public string AddOperation(Model.GettingCommand.Request request)
    {
        if (request.Type == null) return "Operation type is required";
        if (request.BankAccountId == null) return "Bank account id is required";
        if (request.CategoryId == null) return "Category id is required";
        if (request.Amount == null) return "Amount is required";
        try
        {
            // OperationFacade.CreateNewOperation требует репозитории для валидации индексов
            var accountRepo = CompositionRoot.Services.GetRequiredService<IBankAccountRepository>();
            var categoryRepo = CompositionRoot.Services.GetRequiredService<ICategoryRepository>();

            operationFacade.CreateNewOperation(
                request.Type.Value,
                request.BankAccountId.Value,
                request.CategoryId.Value,
                request.Amount.Value,
                accountRepo,
                categoryRepo,
                request.Description ?? ""
            );
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return "Operation created";
    }

    /// <summary>
    /// Обновляет существующую операцию (только описание)
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт</returns>
    public string UpdateOperation(Model.GettingCommand.Request request)
    {
        if (request.Id == null || request.Description == null) return "Incorrect data";
        try
        {
            operationFacade.ChangeOperation(request.Id.Value, request.Description);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return "Operation updated";
    }

    /// <summary>
    /// Удаляет операцию
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт</returns>
    public string RemoveOperation(Model.GettingCommand.Request request)
    {
        if (request.Id == null) return "Id is required";
        try
        {
            operationFacade.DeleteOperation(request.Id.Value);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return "Operation deleted";
    }
}

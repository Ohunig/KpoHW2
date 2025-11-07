using Model = KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic.OperationsModel;

namespace KpoHW2.Application.Interactions.OperationsLogic.Interfaces;

/// <summary>
/// Интерактор экрана операций
/// </summary>
public interface IOperationsInteractor
{
    public void ToStart(Model.EndAction.Request request);

    public void GetCommand(Model.GettingCommand.Request request);

    public string GetOperations(Model.GettingCommand.Request request);

    public string AddOperation(Model.GettingCommand.Request request);

    public string UpdateOperation(Model.GettingCommand.Request request);

    public string RemoveOperation(Model.GettingCommand.Request request);
}
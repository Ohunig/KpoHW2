using KpoHW2.Application.Interactions.OperationsLogic.Commands;
using KpoHW2.Application.Interactions.OperationsLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic.OperationsModel;

public class UpdateOperationCommand(IOperationsInteractor receiver, int? id, string? description = null)
    : ICommand
{
    public IOperationsInteractor receiver = receiver;

    private int? id = id;
    private string? description = description;

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.UpdateOperation(new Model.GettingCommand.Request(null, id, null, null, null, null, description));
    }
}
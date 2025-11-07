using KpoHW2.Application.Interactions.OperationsLogic.Commands;
using KpoHW2.Application.Interactions.OperationsLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic.OperationsModel;

public class RemoveOperationCommand(IOperationsInteractor receiver, int? id) : ICommand
{
    public IOperationsInteractor receiver = receiver;

    private int? id = id;

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.RemoveOperation(new Model.GettingCommand.Request(null, id));
    }
}
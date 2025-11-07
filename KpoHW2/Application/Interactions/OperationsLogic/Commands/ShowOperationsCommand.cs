using KpoHW2.Application.Interactions.OperationsLogic.Commands;
using KpoHW2.Application.Interactions.OperationsLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic.OperationsModel;

public class ShowOperationsCommand(IOperationsInteractor receiver) : ICommand
{
    public IOperationsInteractor receiver = receiver;

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.GetOperations(new Model.GettingCommand.Request());
    }
}
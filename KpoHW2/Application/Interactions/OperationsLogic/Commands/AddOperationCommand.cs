using KpoHW2.Application.Interactions.OperationsLogic.Commands;
using KpoHW2.Application.Interactions.OperationsLogic.Interfaces;
using KpoHW2.Domain.Operation;
using Model = KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic.OperationsModel;

public class AddOperationCommand(IOperationsInteractor receiver, OperationType? type, int? bankAccountId, int? categoryId, int? amount, string? description)
    : ICommand
{
    public IOperationsInteractor receiver = receiver;

    private OperationType? type = type;
    private int? bankAccountId = bankAccountId;
    private int? categoryId = categoryId;
    private int? amount = amount;
    private string? description = description;

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.AddOperation(new Model.GettingCommand.Request(null, null, type, bankAccountId, categoryId, amount, description));
    }
}
using KpoHW2.Application.Interactions.AccountsLogic.Commands;
using KpoHW2.Application.Interactions.AccountsLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic.AccountsModel;


public class RemoveAccountCommand(IAccountsInteractor receiver, int? id) : ICommand
{
    public IAccountsInteractor receiver = receiver;

    private int? id = id;
    
    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.RemoveAccount(new Model.GettingCommand.Request(null, id));
    }
}
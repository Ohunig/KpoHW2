using KpoHW2.Application.Interactions.AccountsLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic.AccountsModel;

public class AddAccountCommand(IAccountsInteractor receiver, string? name) : ICommand
{
    public IAccountsInteractor receiver = receiver;

    private string? name = name;
    
    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.AddAccount(new Model.GettingCommand.Request(null, null, name));
    }
}
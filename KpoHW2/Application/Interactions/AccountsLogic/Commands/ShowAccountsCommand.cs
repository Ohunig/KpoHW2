using KpoHW2.Application.Interactions.AccountsLogic.Commands;
using KpoHW2.Application.Interactions.AccountsLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic.AccountsModel;

public class ShowAccountsCommand(IAccountsInteractor receiver) : ICommand
{
    public IAccountsInteractor receiver = receiver;

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.GetAccounts(new Model.GettingCommand.Request());
    }
}
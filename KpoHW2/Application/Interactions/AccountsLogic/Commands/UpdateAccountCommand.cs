using KpoHW2.Application.Interactions.AccountsLogic.Interfaces;
using Model = KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic.AccountsModel;


public class UpdateAccountCommand(IAccountsInteractor receiver, int? id, string? name = null, int? balance = null)
    : ICommand
{
    public IAccountsInteractor receiver = receiver;

    private int? id = id;

    private string? name = name;

    private int? balance = balance;

    /// <summary>
    /// Выполнение команды
    /// </summary>
    /// <returns>Данные об операции</returns>
    public string Execute()
    {
        return receiver.UpdateAccount(new Model.GettingCommand.Request(null, id, name, balance));
    }
}
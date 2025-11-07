using KpoHW2.Application.Interactions.AccountsLogic.Commands;
using Model = KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic.AccountsModel;

namespace KpoHW2.Application.Interactions.AccountsLogic.Interfaces;

/// <summary>
/// Интерактор выдаёт нужную команду презентеру при вызове GetCommand ->
/// команда с декораторами передаётся в контроллер
/// </summary>
public interface IAccountsInteractor
{
    public void ToStart(Model.EndAction.Request request);
    
    public void GetCommand(Model.GettingCommand.Request request);
    
    public string GetAccounts(Model.GettingCommand.Request request);
    
    public string AddAccount(Model.GettingCommand.Request request);
    
    public string UpdateAccount(Model.GettingCommand.Request request);
    
    public string RemoveAccount(Model.GettingCommand.Request request);
}
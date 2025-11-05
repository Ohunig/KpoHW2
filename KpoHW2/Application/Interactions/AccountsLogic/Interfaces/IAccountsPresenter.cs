using Model = KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic.AccountsModel;

namespace KpoHW2.Application.Interactions.AccountsLogic.Interfaces;

/// <summary>
/// В данном случае презентер декорирует и передаёт получившуюся команду контроллеру
/// Нужен чтобы изолировать interactor от UI
/// </summary>
public interface IAccountsPresenter
{
    public void ToStart(Model.EndAction.Response response);
    
    public void PresentCommand(Model.GettingCommand.Response response);
}
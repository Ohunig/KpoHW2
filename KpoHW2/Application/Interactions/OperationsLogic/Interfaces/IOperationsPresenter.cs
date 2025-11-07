using Model = KpoHW2.Application.Interactions.OperationsLogic.Commands.Interactions.OperationsLogic.OperationsModel;

namespace KpoHW2.Application.Interactions.OperationsLogic.Interfaces;

/// <summary>
/// Презентер экрана операций — декорирует команду и передаёт контроллеру
/// </summary>
public interface IOperationsPresenter
{
    public void ToStart(Model.EndAction.Response response);

    public void PresentCommand(Model.GettingCommand.Response response);
}
using System.Text;
using KpoHW2.Application.Facades;
using KpoHW2.Application.Interactions.AccountsLogic.Interfaces;
using KpoHW2.Domain.BankAccount;
using Model = KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic.AccountsModel;

namespace KpoHW2.Application.Interactions.AccountsLogic.Commands.Interactions.AccountsLogic;

/// <summary>
/// Интерактор экрана аккаунтов
/// Отвечает за прикладную логику экрана
/// </summary>
/// <param name="presenter"></param>
/// <param name="bankAccountFacade"></param>
public class AccountsInteractor(IAccountsPresenter presenter, BankAccountFacade bankAccountFacade) : IAccountsInteractor
{
    private BankAccountFacade bankAccountFacade = bankAccountFacade;

    private IAccountsPresenter presenter = presenter;

    /// <summary>
    /// Подаёт сигнал презентеру вернуться на главный экран
    /// </summary>
    /// <param name="request">Запрос</param>
    public void ToStart(AccountsModel.EndAction.Request request)
    {
        presenter.ToStart(new Model.EndAction.Response());
    }

    /// <summary>
    /// Передаёт нужную команду презентеру
    /// </summary>
    /// <param name="request">Запрос от UI</param>
    public void GetCommand(AccountsModel.GettingCommand.Request request)
    {
        switch (request.Option)
        {
            case 1:
                var showCommand = new ShowAccountsCommand(this);
                presenter.PresentCommand(new Model.GettingCommand.Response(showCommand));
                break;
            case 2:
                var addCommand = new AddAccountCommand(this, request.Name);
                presenter.PresentCommand(new Model.GettingCommand.Response(addCommand));
                break;
            case 3:
                var updateCommand = new UpdateAccountCommand(this, request.Id, request.Name, request.Balance);
                presenter.PresentCommand(new Model.GettingCommand.Response(updateCommand));
                break;
            case 4:
                var removeCommand = new RemoveAccountCommand(this, request.Id);
                presenter.PresentCommand(new Model.GettingCommand.Response(removeCommand));
                break;
        }
    }

    /// <summary>
    /// Отдаёт отчёт со всеми аккаунтами
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт с данными аккаунтов</returns>
    public string GetAccounts(AccountsModel.GettingCommand.Request request)
    {
        StringBuilder message = new StringBuilder();
        List<int> idList = bankAccountFacade.IdList.ToList();
        for (int i = 0; i < idList.Count; i++)
        {
            BankAccount account = bankAccountFacade.GetAccount(idList[i]);
            message.AppendLine($"{account.Id}.\tName: {account.Name}\tBalance: {account.Balance}$");
        }

        return message.ToString();
    }

    /// <summary>
    /// Добавляет новый аккаунт
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт</returns>
    public string AddAccount(AccountsModel.GettingCommand.Request request)
    {
        if (request.Name == null) return "Name is required";
        try
        {
            bankAccountFacade.CreateNewAccount(request.Name);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return "Account created";
    }

    /// <summary>
    /// Изменяет существующий аккаунт
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт</returns>
    public string UpdateAccount(AccountsModel.GettingCommand.Request request)
    {
        if (request.Id == null || request.Name == null || request.Balance == null) return "Incorrect data";
        try
        {
            bankAccountFacade.ChangeAccount(request.Id.Value, request.Name, request.Balance);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return "Account updated";
    }

    /// <summary>
    /// Удаляет аккаунт
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <returns>Отчёт</returns>
    public string RemoveAccount(AccountsModel.GettingCommand.Request request)
    {
        if (request.Id == null) return "Id is required";
        try
        {
            bankAccountFacade.DeleteAccount(request.Id.Value);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return "Account deleted";
    }
}
using KpoHW2.Application.Ports;
using KpoHW2.Domain.BankAccount;

namespace KpoHW2.Infrastructure.Factories;

public class StandartBankAccountFactory : IAccountFactory
{
    private class Constants
    {
        public static readonly String nameError = "Name cannot be empty";
    }
    
    private IIdManager idManager;

    public StandartBankAccountFactory(IIdManager idManager)
    {
        this.idManager = idManager;
    }

    /// <summary>
    /// Создаёт аккаунт
    /// </summary>
    /// <param name="name">Имя аккаунта</param>
    /// <returns>Новый аккаунт</returns>
    /// <exception cref="ArgumentException">При пустом имени</exception>
    public BankAccount Create(string name)
    {
        if (name == String.Empty)
        {
            throw new ArgumentException(Constants.nameError);
        }
        return new BankAccount(idManager.getUniqueId(), name, 0);
    }
}
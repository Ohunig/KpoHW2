using KpoHW2.Domain.BankAccount;

namespace KpoHW2.Application.Facades;

public class BankAccountFacade
{
    private IAccountFactory bankAccountFactory;

    private IBankAccountRepository bankAccountRepository;
    
    public List<int> IdList => bankAccountRepository.IdList;

    /// <summary>
    /// Стандартный конструктор
    /// Использование интерфейсов обусловлено облегчением тестирования фасада
    /// </summary>
    /// <param name="bankAccountFactory">Фабрика аккаунтов</param>
    /// <param name="bankAccountRepository">Репозиторий для аккаунтов</param>
    public BankAccountFacade(IAccountFactory bankAccountFactory,
        IBankAccountRepository bankAccountRepository)
    {
        this.bankAccountFactory = bankAccountFactory;
        this.bankAccountRepository = bankAccountRepository;
    }

    /// <summary>
    /// Создаёт новый аккаунт
    /// </summary>
    /// <param name="name">Имя нового аккаунта</param>
    /// <exception cref="ArgumentException">При пустом имени</exception>
    public void CreateNewAccount(String name)
    {
        BankAccount account = bankAccountFactory.Create(name);
        bankAccountRepository.Add(account);
    }

    /// <summary>
    /// Находит аккаунт по id
    /// </summary>
    /// <param name="id">id аккаунта</param>
    /// <returns>Аккаунт с нужным id</returns>
    /// <exception cref="ArgumentException">Когда аккаунта с таким id не существует</exception>
    public BankAccount GetAccount(int id)
    {
        return bankAccountRepository.Get(id);
    }

    /// <summary>
    /// Изменяет аккаунт с указанным id
    /// </summary>
    /// <param name="id">id аккаунта</param>
    /// <param name="name">Новое имя или nil если менять не нужно</param>
    /// <param name="balance">Обновлённый баланс или nil если менять не нужно</param>
    /// <exception cref="ArgumentException">Если не существует аккаунта с таким id или указанны некорректные данные</exception>
    public void ChangeAccount(int id, string? name = null, int? balance = null)
    {
        BankAccount account = bankAccountRepository.Get(id);
        if (name != null)
            account.UpdateName(name);
        if (balance.HasValue)
            account.UpdateBalance(balance.Value);
        bankAccountRepository.Update(id, account);
    }

    /// <summary>
    /// Находит и удаляет аккаунт по id
    /// </summary>
    /// <param name="id">id аккаунта</param>
    /// <exception cref="ArgumentException">Когда аккаунта с таким id не существует</exception>
    public void DeleteAccount(int id)
    {
        bankAccountRepository.Delete(id);
    }
}
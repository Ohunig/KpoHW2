using KpoHW2.Domain.BankAccount;

namespace KpoHW2.Infrastructure.Persistence;

public class StandartBankAccountRepository : IBankAccountRepository
{
    private class Constants
    {
        public static readonly String idError = "Account with this id doesn't exist";
    }

    private Dictionary<int, BankAccount> bankAccounts = new Dictionary<int, BankAccount>();

    public int Count => bankAccounts.Count;

    public List<int> IdList => bankAccounts.Keys.ToList();

    public void Add(BankAccount bankAccount)
    {
        bankAccounts[bankAccount.Id] = bankAccount;
    }

    public BankAccount Get(int id)
    {
        if (!bankAccounts.ContainsKey(id)) throw new ArgumentException(Constants.idError);
        return bankAccounts[id];
    }

    public void Update(int id, BankAccount bankAccount)
    {
        if (!bankAccounts.ContainsKey(id)) throw new ArgumentException(Constants.idError);
        bankAccounts[id] = bankAccount;
    }

    public void Delete(int id)
    {
        if (!bankAccounts.ContainsKey(id)) throw new ArgumentException(Constants.idError);
        bankAccounts.Remove(id);
    }
}
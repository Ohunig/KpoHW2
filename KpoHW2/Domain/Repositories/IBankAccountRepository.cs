using KpoHW2.Domain.BankAccount;

public interface IBankAccountRepository
{
    public List<int> IdList { get; }
    public void Add(BankAccount bankAccount);

    public BankAccount Get(int id);

    public void Update(int id, BankAccount bankAccount);

    public void Delete(int id);
}
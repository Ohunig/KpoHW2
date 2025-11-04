using KpoHW2.Domain.BankAccount;

public interface IAccountFactory
{
    public BankAccount Create(string name);
}
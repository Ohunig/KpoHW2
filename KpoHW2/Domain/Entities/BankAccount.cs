namespace KpoHW2.Domain.BankAccount;

public struct BankAccount
{
    private class Constants
    {
        public static readonly string NameError = "Name can not be empty";
        public static readonly string BalanceError = "Balance can not be negative";
    }
    
    public int Id { get; }
    public string Name { get; private set; }
    public int Balance { get; private set; }
    
    public BankAccount(int id, string name, int balance)
    {
        Id = id;
        Name = name;
        Balance = balance;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException(Constants.NameError);
        Name = name;
    }

    public void UpdateBalance(int balance)
    {
        if (balance < 0) throw new ArgumentException(Constants.BalanceError);
        Balance = balance;
    }
}
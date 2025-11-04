namespace KpoHW2.Domain.Operation;

public struct Operation
{
    public int Id { get; }

    public OperationType Type { get; }

    public int BankAccountId { get; }

    public int Amount { get; }

    public DateTime Date { get; }

    public String Description { get; set; }

    public int CategoryId { get; }

    public Operation(int id, OperationType type, int bankAccountId, int amount, DateTime date, int categoryId,
        String description = "")
    {
        Id = id;
        Type = type;
        BankAccountId = bankAccountId;
        Amount = amount;
        Date = date;
        Description = description;
        CategoryId = categoryId;
    }
}
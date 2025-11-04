using KpoHW2.Domain.Operation;

public interface IOperationFactory
{
    public Operation Create(OperationType type, int bankAccountId, int amount, DateTime date, int categoryId,
        String description = "");

    public bool ValidateIndices(IBankAccountRepository accountRepository, int bankAccountId,
        ICategoryRepository categoryRepository, int categoryId);
}
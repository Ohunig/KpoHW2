using KpoHW2.Domain.Operation;

namespace KpoHW2.Infrastructure.Factories;

public class StandartOperationFactory : IOperationFactory
{
    private class Constants
    {
        public static readonly String amountError = "Amount can not be negative";
    }

    private IIdManager idManager;

    public StandartOperationFactory(IIdManager idManager)
    {
        this.idManager = idManager;
    }

    public Operation Create(OperationType type, int bankAccountId, int amount, DateTime date, int categoryId,
        String description = "")
    {
        if (amount < 0) throw new ArgumentException(Constants.amountError);
        return new Operation(idManager.getUniqueId(), type, bankAccountId, amount, date, categoryId, description);
    }

    public bool ValidateIndices(IBankAccountRepository accountRepository, int bankAccountId,
        ICategoryRepository categoryRepository, int categoryId)
    {
        try
        {
            accountRepository.Get(bankAccountId);
            categoryRepository.Get(categoryId);
        }
        catch
        {
            return false;
        }
        return true;
    }
}
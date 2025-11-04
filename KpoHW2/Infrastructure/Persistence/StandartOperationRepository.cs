using KpoHW2.Domain.Operation;

namespace KpoHW2.Infrastructure.Persistence;

public class StandartOperationRepository : IOperationRepository
{
    private class Constants
    {
        public static readonly String idError = "Account with this id doesn't exist";
    }

    private Dictionary<int, Operation> operations = new Dictionary<int, Operation>();

    public List<int> IdList => operations.Keys.ToList();

    public void Add(Operation operation)
    {
        operations[operation.Id] = operation;
    }

    public Operation Get(int id)
    {
        if (!operations.ContainsKey(id)) throw new ArgumentException(Constants.idError);
        return operations[id];
    }
    
    public void Update(int id, Operation operation)
    {
        if (!operations.ContainsKey(id)) throw new ArgumentException(Constants.idError);
        operations[id] = operation;
    }

    public void Delete(int id)
    {
        if (!operations.ContainsKey(id)) throw new ArgumentException(Constants.idError);
        operations.Remove(id);
    }
}
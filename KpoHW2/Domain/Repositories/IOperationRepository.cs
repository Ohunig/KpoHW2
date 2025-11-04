using KpoHW2.Domain.Operation;

public interface IOperationRepository
{
    public List<int> IdList { get; }
    
    public void Add(Operation operation);

    public Operation Get(int id);
    
    public void Update(int id, Operation operation);

    public void Delete(int id);
}
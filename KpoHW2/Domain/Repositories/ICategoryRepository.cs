using KpoHW2.Domain.Category;

public interface ICategoryRepository
{
    public List<int> IdList { get; }
    public void Add(Category category);
    
    public Category Get(int id);

    public void Update(int id, Category category);

    public void Delete(int id);
}
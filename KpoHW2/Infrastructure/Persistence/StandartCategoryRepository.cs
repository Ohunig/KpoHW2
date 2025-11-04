using KpoHW2.Domain.Category;

namespace KpoHW2.Infrastructure.Persistence;

public class StandartCategoryRepository : ICategoryRepository
{
    private class Constants
    {
        public static readonly String idError = "Account with this id doesn't exist";
    }
    
    private Dictionary<int, Category> categories = new Dictionary<int, Category>();
    
    public int Count => categories.Count;

    public List<int> IdList => categories.Keys.ToList();

    public void Add(Category category)
    {
        categories[category.Id] = category;
    }

    public Category Get(int id)
    {
        if (!categories.ContainsKey(id)) throw new ArgumentException(Constants.idError);
        return categories[id];
    }
    
    public void Update(int id, Category category)
    {
        if (!categories.ContainsKey(id)) throw new ArgumentException(Constants.idError);
        categories[id] = category;
    }

    public void Delete(int id)
    {
        if (!categories.ContainsKey(id)) throw new ArgumentException(Constants.idError);
        categories.Remove(id);
    }
}
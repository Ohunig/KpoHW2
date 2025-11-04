namespace KpoHW2.Domain.Category;

public struct Category
{
    private class Constants
    {
        public static readonly string NameError = "Name can not be empty";
    }
    
    public int Id { get; }
    
    public CategoryType CategoryType { get; }
    
    public string Name { get; private set; }
    
    public Category(int id, CategoryType categoryType, string name)
    {
        Id = id;
        CategoryType = categoryType;
        Name = name;
    }
    
    public void UpdateName(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException(Constants.NameError);
        Name = name;
    }
}
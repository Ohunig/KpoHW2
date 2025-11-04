using KpoHW2.Domain.Category;

public interface ICategoryFactory
{
    public Category Create(String name, CategoryType categoryType);
}
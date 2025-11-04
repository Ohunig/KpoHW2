using KpoHW2.Domain.Category;

namespace KpoHW2.Infrastructure.Factories;

public class StandartCategoryFactory : ICategoryFactory
{
    private class Constants
    {
        public static readonly String nameError = "Name cannot be empty";
    }
    
    private IIdManager idManager;

    public StandartCategoryFactory(IIdManager idManager)
    {
        this.idManager = idManager;
    }

    public Category Create(String name, CategoryType categoryType)
    {
        if (name == String.Empty)
        {
            throw new ArgumentException(Constants.nameError);
        }
        return new Category(idManager.getUniqueId(), categoryType, name);
    }
}
using KpoHW2.Domain.Category;

namespace KpoHW2.Application.Facades;

public class CategoryFacade
{
    private ICategoryFactory categoryFactory;

    private ICategoryRepository categoryRepository;
    
    public List<int> IdList => categoryRepository.IdList;

    /// <summary>
    /// Стандартный конструктор
    /// Использование интерфейсов обусловлено облегчением тестирования фасада
    /// </summary>
    /// <param name="categoryFactory">Фабрика категорий</param>
    /// <param name="categoryRepository">Репозиторий для категорий</param>
    public CategoryFacade(ICategoryFactory categoryFactory,
        ICategoryRepository categoryRepository)
    {
        this.categoryFactory = categoryFactory;
        this.categoryRepository = categoryRepository;
    }

    /// <summary>
    /// Создаёт новую категорию
    /// </summary>
    /// <param name="name">Имя новой категории</param>
    /// <param name="type">Тип категории</param>
    /// <exception cref="ArgumentException">При пустом имени</exception>
    public void CreateNewCategory(String name, CategoryType type)
    {
        Category category = categoryFactory.Create(name, type);
        categoryRepository.Add(category);
    }

    /// <summary>
    /// Находит категорию по id
    /// </summary>
    /// <param name="id">id категории</param>
    /// <returns>Категория с нужным id</returns>
    /// <exception cref="ArgumentException">Когда категории с таким id не существует</exception>
    public Category GetCategory(int id)
    {
        return categoryRepository.Get(id);
    }

    /// <summary>
    /// Изменяет категорию с указанным id
    /// </summary>
    /// <param name="id">id категории</param>
    /// <param name="name">Новое имя или nil если менять не нужно</param>
    /// <exception cref="ArgumentException">Если не существует категории с таким id или указаны некорректные данные</exception>
    public void ChangeCategory(int id, string? name = null)
    {
        Category category = categoryRepository.Get(id);
        if (name != null)
            category.UpdateName(name);
        categoryRepository.Update(id, category);
    }

    /// <summary>
    /// Находит и удаляет категорию по id
    /// </summary>
    /// <param name="id">id категории</param>
    /// <exception cref="ArgumentException">Когда категории с таким id не существует</exception>
    public void DeleteCategory(int id)
    {
        categoryRepository.Delete(id);
    }
}
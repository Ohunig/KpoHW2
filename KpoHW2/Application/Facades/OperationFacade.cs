using KpoHW2.Domain.Operation;

namespace KpoHW2.Application.Facades;

public class OperationFacade
{
    private class Constants
    {
        public static readonly string IndicesError = "Incorrect indices";
    }

    private IOperationFactory operationFactory;

    private IOperationRepository operationRepository;
    
    public List<int> IdList => operationRepository.IdList;

    /// <summary>
    /// Стандартный конструктор
    /// Использование интерфейсов обусловлено облегчением тестирования фасада
    /// </summary>
    /// <param name="operationFactory">Фабрика операций</param>
    /// <param name="operationRepository">Репозиторий для операций</param>
    public OperationFacade(IOperationFactory operationFactory,
        IOperationRepository operationRepository)
    {
        this.operationFactory = operationFactory;
        this.operationRepository = operationRepository;
    }

    /// <summary>
    /// Создаёт новую операцию
    /// </summary>
    /// <param name="type">Тип операции</param>
    /// <param name="accountId">Id аккаунта к которому привязана операция</param>
    /// <param name="categoryId">Id категории операции</param>
    /// <param name="amount">Сумма операции</param>
    /// <param name="accountRepository">Репозиторий аккаунтов для проверки корректности id</param>
    /// <param name="categoryRepository">Репозиторий категорий для проверки корректности id</param>
    /// <param name="description">Описание операции</param>
    /// <exception cref="ArgumentException">Если индексы некорректны или сумма операции отрицательна</exception>
    public void CreateNewOperation(OperationType type, int accountId, int categoryId, int amount,
        IBankAccountRepository accountRepository, ICategoryRepository categoryRepository, string description = "")
    {
        if (operationFactory.ValidateIndices(accountRepository, accountId, categoryRepository, categoryId))
        {
            Operation operation =
                operationFactory.Create(type, accountId, amount, DateTime.Now, categoryId, description);
            operationRepository.Add(operation);
        }
        else
        {
            throw new ArgumentException(Constants.IndicesError);
        }
    }

    /// <summary>
    /// Находит операцию по id
    /// </summary>
    /// <param name="id">id операции</param>
    /// <returns>Операция с нужным id</returns>
    /// <exception cref="ArgumentException">Когда операции с таким id не существует</exception>
    public Operation GetOperation(int id)
    {
        return operationRepository.Get(id);
    }

    /// <summary>
    /// Изменяет операцию с указанным id
    /// Изменение только описания так как не можем позволить менять сумму операции, а тем более
    /// аккаунт и категорию к которым относится операция. Дату тоже обязаны сохранить изначальную.
    /// </summary>
    /// <param name="id">id операции</param>
    /// <param name="description">Новое описание</param>
    /// <exception cref="ArgumentException">Если не существует операции с таким id</exception>
    public void ChangeOperation(int id, string description)
    {
        Operation operation = operationRepository.Get(id);
        operation.Description = description;
        operationRepository.Update(id, operation);
    }

    /// <summary>
    /// Находит и удаляет операцию по id
    /// </summary>
    /// <param name="id">id операции</param>
    /// <exception cref="ArgumentException">Когда операции с таким id не существует</exception>
    public void DeleteOperation(int id)
    {
        operationRepository.Delete(id);
    }
}
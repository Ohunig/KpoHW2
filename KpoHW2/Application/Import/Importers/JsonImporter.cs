using System.Text.Json;

/// <summary>
/// Импортер из Json
/// </summary>
/// <typeparam name="TDto">Модель данных об объекте</typeparam>
public class JsonImporter<TDto> : AbstractImporter<TDto>
{
    private readonly JsonSerializerOptions _options;
    private readonly Func<TDto, (bool, string?)> _processFunc;
    
    /// <summary>
    /// Стандартный конструктор
    /// </summary>
    public JsonImporter()
    {
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
    
    /// <summary>
    /// Читает данные из потока
    /// </summary>
    /// <param name="stream">Поток</param>
    /// <returns>Список данных об объектах</returns>
    protected override IEnumerable<TDto> ReadRecordsFromStream(Stream stream)
    {
        var list = JsonSerializer.DeserializeAsync<List<TDto>>(stream, _options).GetAwaiter().GetResult();
        return list ?? new List<TDto>();
    }
    
    /// <summary>
    /// При создании конкретных json-импортеров метод должен переопределяться так как нет базовой реализации
    /// </summary>
    /// <param name="dto">Данные об объекте</param>
    /// <returns>(успех, ошибка)</returns>
    /// <exception cref="NotImplementedException"></exception>
    protected override (bool success, string? error) ProcessRecord(TDto dto)
    {
        // чтобы класс компилировался при наследовании, но мы не используем этот базовый метод.
        throw new NotImplementedException("Concrete importer should implement ProcessRecord");
    }
}
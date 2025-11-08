using KpoHW2.Application.Import;

/// <summary>
/// Абстрактный импортер
/// Реализует паттерн шаблонный метод (главный метод Import использует методы ReadRecordsFromStream, ProcessRecord)
/// </summary>
public abstract class AbstractImporter<TDto>
{
    /// <summary>
    /// Импорт данных
    /// </summary>
    /// <param name="filePath">Путь до файла</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Пустой путь</exception>
    /// <exception cref="FileNotFoundException">Файл не найден</exception>
    public ImportResult Import(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException(nameof(filePath));
        if (!File.Exists(filePath)) throw new FileNotFoundException("File not found", filePath);

        var errors = new List<string>();
        int imported = 0, failed = 0, row = 0;

        using var stream = File.OpenRead(filePath);
        var records = ReadRecordsFromStream(stream).ToList();

        foreach (var dto in records)
        {
            row++;
            try
            {
                var (ok, error) = ProcessRecord(dto);
                if (ok) imported++;
                else
                {
                    failed++;
                    errors.Add($"Row {row}: {error ?? "unknown error"}");
                }
            }
            catch (Exception ex)
            {
                failed++;
                errors.Add($"Row {row}: exception: {ex.Message}");
            }
        }

        return new ImportResult(imported, failed, errors);
    }

    /// <summary>
    /// Читает записи из потока
    /// </summary>
    /// <param name="stream">поток</param>
    /// <returns>Список дто</returns>
    protected abstract IEnumerable<TDto> ReadRecordsFromStream(Stream stream);
    
    /// <summary>
    /// Добавляет объект в базу
    /// </summary>
    /// <param name="dto">Объект с данными для создания объекта через фасад</param>
    /// <returns>(успешно, сообщение об ошибке)</returns>
    protected abstract (bool success, string? error) ProcessRecord(TDto dto);
}
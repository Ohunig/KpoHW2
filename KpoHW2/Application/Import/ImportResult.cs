namespace KpoHW2.Application.Import;

/// <summary>
/// Результаты импорта
/// </summary>
/// <param name="Imported">Сколько объектов успешно импортировано</param>
/// <param name="Failed">Сколько объектов не получилось импортировать</param>
/// <param name="Errors">Список ошибок</param>
public record ImportResult(int Imported, int Failed, IReadOnlyList<string> Errors);
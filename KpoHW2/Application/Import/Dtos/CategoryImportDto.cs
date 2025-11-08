namespace KpoHW2.Application.Import.Dtos;

/// <summary>
/// Модель для данных категории
/// Позволяет в дальнейшем создать категорию через фасад
/// </summary>
public class CategoryImportDto
{
    public string? Name { get; set; }
    public string? CategoryType { get; set; }
}
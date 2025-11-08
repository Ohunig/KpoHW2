namespace KpoHW2.Application.Import.Dtos;

/// <summary>
/// Модель для данных операции
/// Позволяет в дальнейшем создать операцию через фасад
/// </summary>
public class OperationImportDto
{
    public string? Type { get; set; }
    public int? BankAccountId { get; set; }
    public int? CategoryId { get; set; }
    public int? Amount { get; set; }
    public string? Date { get; set; }
    public string? Description { get; set; }
}
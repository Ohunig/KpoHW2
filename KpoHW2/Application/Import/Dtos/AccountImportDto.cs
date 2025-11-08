namespace KpoHW2.Application.Import.Dtos;

/// <summary>
/// Модель для данных аккаунта
/// Позволяет в дальнейшем создать аккаунт через фасад
/// </summary>
public class AccountImportDto
{
    public string? Name { get; set; } 
    public int? Balance { get; set; }
}
using KpoHW2.Application.Import.Dtos;
using KpoHW2.Application.Facades;

namespace KpoHW2.Application.Import.Importers.AccountImporters;

/// <summary>
/// Конкретный Json импортер для аккаунтов
/// </summary>
public class AccountJsonImporter : JsonImporter<AccountImportDto>
{
    private readonly BankAccountFacade _facade;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="facade">Фасад для аккаунтов</param>
    /// <exception cref="ArgumentNullException">Если не передан фасад</exception>
    public AccountJsonImporter(BankAccountFacade facade)
    {
        _facade = facade ?? throw new ArgumentNullException(nameof(facade));
    }

    /// <summary>
    /// Добавляет аккаунт
    /// </summary>
    /// <param name="dto">Данные об аккаунте</param>
    /// <returns>(успех/неудача, ошибка)</returns>
    protected override (bool success, string? error) ProcessRecord(AccountImportDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name)) return (false, "Name is required");
        try
        {
            _facade.CreateNewAccount(dto.Name);
            if (dto.Balance.HasValue)
            {
                var id = _facade.IdList.Count > 0 ? _facade.IdList[^1] : -1;
                if (id != -1) _facade.ChangeAccount(id, null, dto.Balance);
            }

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
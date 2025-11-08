using KpoHW2.Application.Import.Dtos;
using KpoHW2.Application.Facades;

namespace KpoHW2.Application.Import.Importers.AccountImporters;

public class AccountCsvImporter : CsvImporter<AccountImportDto>
{
    private readonly BankAccountFacade _facade;

    public AccountCsvImporter(BankAccountFacade facade)
        : base((headers, fields) =>
        {
            string? get(string name)
            {
                for (int i = 0; i < headers.Length; i++)
                    if (string.Equals(headers[i], name, StringComparison.OrdinalIgnoreCase))
                        return i < fields.Length ? fields[i] : null;
                return null;
            }

            var name = get("Name");
            var bal = get("Balance");
            int.TryParse(bal, out var b);
            return new AccountImportDto { Name = name, Balance = string.IsNullOrWhiteSpace(bal) ? (int?)null : b };
        })
    {
        _facade = facade ?? throw new ArgumentNullException(nameof(facade));
    }

    protected override (bool success, string? error) ProcessRecord(AccountImportDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name)) return (false, "Name is required");
        try
        {
            _facade.CreateNewAccount(dto.Name);
            if (dto.Balance.HasValue)
            {
                var id = _facade.IdList.Count > 0 ? _facade.IdList[^1] : 0;
                if (id != 0) _facade.ChangeAccount(id, null, dto.Balance);
            }

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
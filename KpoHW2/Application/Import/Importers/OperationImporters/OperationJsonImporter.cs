using KpoHW2.Application.Import.Dtos;
using KpoHW2.Application.Facades;
using KpoHW2.Domain.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace KpoHW2.Application.Import.Importers.OperationImporters;

public class OperationJsonImporter : JsonImporter<OperationImportDto>
{
    private readonly OperationFacade _facade;
    private readonly IBankAccountRepository _accountRepo;
    private readonly ICategoryRepository _categoryRepo;

    public OperationJsonImporter(OperationFacade facade, IServiceProvider services)
    {
        _facade = facade ?? throw new ArgumentNullException(nameof(facade));
        _accountRepo = services.GetRequiredService<IBankAccountRepository>();
        _categoryRepo = services.GetRequiredService<ICategoryRepository>();
    }

    protected override (bool success, string? error) ProcessRecord(OperationImportDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Type)) return (false, "Type required");
        if (!dto.BankAccountId.HasValue) return (false, "BankAccountId required");
        if (!dto.CategoryId.HasValue) return (false, "CategoryId required");
        if (!dto.Amount.HasValue) return (false, "Amount required");

        try
        {
            OperationType opType;
            if (int.TryParse(dto.Type, out var n)) opType = (OperationType)n;
            else if (!Enum.TryParse<OperationType>(dto.Type, true, out opType))
                return (false, $"Unknown OperationType: {dto.Type}");

            DateTime date = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(dto.Date) && !DateTime.TryParse(dto.Date, out date))
                return (false, $"Bad date: {dto.Date}");

            _facade.CreateNewOperation(opType, dto.BankAccountId.Value, dto.CategoryId.Value,
                dto.Amount.Value, _accountRepo, _categoryRepo, dto.Description ?? string.Empty);

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
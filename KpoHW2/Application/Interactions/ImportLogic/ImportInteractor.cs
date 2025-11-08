using System.Text;
using KpoHW2.Application.Facades;
using KpoHW2.Application.Interactions.ImportLogic.Interfaces;
using KpoHW2.Application.Import;
using KpoHW2.Application.Import.Importers.AccountImporters;
using KpoHW2.Application.Import.Importers.OperationImporters;
using Microsoft.Extensions.DependencyInjection;

namespace KpoHW2.Application.Interactions.ImportLogic;
    
public class ImportInteractor : IImportInteractor
{
    private readonly IImportPresenter _presenter;
    private readonly IServiceProvider _services;
    private readonly BankAccountFacade _accountFacade;
    private readonly CategoryFacade _categoryFacade;
    private readonly OperationFacade _operationFacade;

    public ImportInteractor(IImportPresenter presenter,
        IServiceProvider services,
        BankAccountFacade accountFacade,
        CategoryFacade categoryFacade,
        OperationFacade operationFacade)
    {
        _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        _services = services ?? throw new ArgumentNullException(nameof(services));
        _accountFacade = accountFacade ?? throw new ArgumentNullException(nameof(accountFacade));
        _categoryFacade = categoryFacade ?? throw new ArgumentNullException(nameof(categoryFacade));
        _operationFacade = operationFacade ?? throw new ArgumentNullException(nameof(operationFacade));
    }

    public void ToStart() => _presenter.ToStart();

    public void ImportAccounts(ImportFormat format, string filePath)
    {
        try
        {
            ImportResult result = format switch
            {
                ImportFormat.Json => _services.GetRequiredService<AccountJsonImporter>().Import(filePath),
                ImportFormat.Csv => _services.GetRequiredService<AccountCsvImporter>().Import(filePath),
                _ => throw new ArgumentException("Unsupported format")
            };

            _presenter.PresentImportResult(FormatResult("Accounts", result));
        }
        catch (Exception ex)
        {
            _presenter.PresentImportResult($"Import accounts failed: {ex.Message}");
        }
    }

    public void ImportCategories(ImportFormat format, string filePath)
    {
        try
        {
            ImportResult result = format switch
            {
                ImportFormat.Json => _services.GetRequiredService<CategoryJsonImporter>().Import(filePath),
                ImportFormat.Csv => _services.GetRequiredService<CategoryCsvImporter>().Import(filePath),
                _ => throw new ArgumentException("Unsupported format")
            };

            _presenter.PresentImportResult(FormatResult("Categories", result));
        }
        catch (Exception ex)
        {
            _presenter.PresentImportResult($"Import categories failed: {ex.Message}");
        }
    }

    public void ImportOperations(ImportFormat format, string filePath)
    {
        try
        {
            ImportResult result = format switch
            {
                ImportFormat.Json => _services.GetRequiredService<OperationJsonImporter>().Import(filePath),
                ImportFormat.Csv => _services.GetRequiredService<OperationCsvImporter>().Import(filePath),
                _ => throw new ArgumentException("Unsupported format")
            };

            _presenter.PresentImportResult(FormatResult("Operations", result));
        }
        catch (Exception ex)
        {
            _presenter.PresentImportResult($"Import operations failed: {ex.Message}");
        }
    }

    private static string FormatResult(string title, ImportResult result)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{title} import result: imported={result.Imported}, failed={result.Failed}");
        if (result.Errors != null && result.Errors.Count > 0)
        {
            sb.AppendLine("Errors:");
            foreach (var e in result.Errors.Take(20)) // ограничим вывод
                sb.AppendLine($" - {e}");
            if (result.Errors.Count > 20) sb.AppendLine($" ... and {result.Errors.Count - 20} more");
        }

        return sb.ToString();
    }
}
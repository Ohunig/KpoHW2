using KpoHW2.Application.Facades;
using KpoHW2.Application.Import.Dtos;
using KpoHW2.Application.Import.Importers;
using KpoHW2.Domain.Category;


public class CategoryCsvImporter : CsvImporter<CategoryImportDto>
{
    private readonly CategoryFacade _facade;

    public CategoryCsvImporter(CategoryFacade facade)
        : base((headers, fields) =>
        {
            string? get(string name)
            {
                for (int i = 0; i < headers.Length; i++)
                    if (string.Equals(headers[i], name, StringComparison.OrdinalIgnoreCase))
                        return i < fields.Length ? fields[i] : null;
                return null;
            }

            return new CategoryImportDto { Name = get("Name"), CategoryType = get("CategoryType") };
        })
    {
        _facade = facade ?? throw new ArgumentNullException(nameof(facade));
    }

    protected override (bool success, string? error) ProcessRecord(CategoryImportDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name)) return (false, "Name is required");
        if (string.IsNullOrWhiteSpace(dto.CategoryType)) return (false, "CategoryType is required");
        try
        {
            if (int.TryParse(dto.CategoryType, out var num))
            {
                _facade.CreateNewCategory(dto.Name, (CategoryType)num);
            }
            else if (Enum.TryParse<CategoryType>(dto.CategoryType, true, out var ct))
            {
                _facade.CreateNewCategory(dto.Name, ct);
            }
            else return (false, $"Unknown CategoryType: {dto.CategoryType}");

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
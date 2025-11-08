using KpoHW2.Application.Import.Dtos;
using KpoHW2.Application.Facades;
using KpoHW2.Domain.Category;

public class CategoryJsonImporter : JsonImporter<CategoryImportDto>
{
    private readonly CategoryFacade _facade;

    public CategoryJsonImporter(CategoryFacade facade) => _facade = facade;

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
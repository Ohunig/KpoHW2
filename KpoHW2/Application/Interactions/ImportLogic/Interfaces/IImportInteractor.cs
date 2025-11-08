using KpoHW2.Application.Import;

namespace KpoHW2.Application.Interactions.ImportLogic.Interfaces;

public interface IImportInteractor
{
    void ToStart();
    void ImportAccounts(ImportFormat format, string filePath);
    void ImportCategories(ImportFormat format, string filePath);
    void ImportOperations(ImportFormat format, string filePath);
}
using System.Text;

namespace KpoHW2.Application.Import.Importers;

/// <summary>
/// Импортер из csv
/// </summary>
/// <typeparam name="TDto">Модель данных об объекте</typeparam>
public class CsvImporter<TDto> : AbstractImporter<TDto>
{
    private readonly Func<string[], string[], TDto> _mapFunc;
    private readonly char _sep;

    public CsvImporter(Func<string[], string[], TDto> mapFunc, char separator = ',')
    {
        _mapFunc = mapFunc ?? throw new ArgumentNullException(nameof(mapFunc));
        _sep = separator;
    }

    protected override IEnumerable<TDto> ReadRecordsFromStream(Stream stream)
    {
        using var rdr = new StreamReader(stream, Encoding.UTF8);
        var headerLine = rdr.ReadLine();
        if (headerLine == null) yield break;
        var headers = SplitLine(headerLine).ToArray();

        string? line;
        while ((line = rdr.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var fields = SplitLine(line).ToArray();
            yield return _mapFunc(headers, fields);
        }
    }

    private IEnumerable<string> SplitLine(string line)
    {
        var parts = line.Split(_sep);
        foreach (var p in parts) yield return p.Trim().Trim('"', '\'');
    }

    protected override (bool success, string? error) ProcessRecord(TDto dto)
    {
        throw new NotImplementedException("Concrete importer must implement ProcessRecord");
    }
}
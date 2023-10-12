using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace PontoCerto.WebApplication.Infrastructure.Helpers;

public class CsvHelper<T> : ICsvHelper<T>
{
    private readonly CsvConfiguration _csvConfiguration;

    public CsvHelper(CsvConfiguration? csvConfiguration)
    {
        _csvConfiguration = csvConfiguration ?? new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            NewLine = Environment.NewLine,
            PrepareHeaderForMatch = args => args.Header.ToLower(),
            HasHeaderRecord = false,
            Delimiter = ";"
        };
    }
    
    public IEnumerable<T> GetRecords(IFormFile file)
    {
        IEnumerable<T> records;
        
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            using (var csv = new CsvReader(reader, _csvConfiguration))
            {
                records = csv.GetRecords<T>().Skip(1).ToList();
            }
        }

        return records;
    }
}
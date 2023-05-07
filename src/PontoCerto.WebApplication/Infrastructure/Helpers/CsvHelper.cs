using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace PontoCerto.WebApplication.Infrastructure.Helpers;

public class CsvHelper<T> : ICsvHelper<T>
{
    private readonly CsvConfiguration _csvConfiguration = new(CultureInfo.CurrentCulture)
    {
        NewLine = Environment.NewLine,
        PrepareHeaderForMatch = args => args.Header.ToLower(),
        HasHeaderRecord = false,
        Delimiter = ";"
    };

    public CsvHelper()
    {
        
    }
    
    public List<T> GetRecords(IFormFile file)
    {
        List<T> records;
        
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
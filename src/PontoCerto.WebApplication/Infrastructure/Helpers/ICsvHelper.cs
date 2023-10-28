namespace PontoCerto.WebApplication.Infrastructure.Helpers;

public interface ICsvHelper<T>
{
    IEnumerable<T> GetRecords(IFormFile file);
}
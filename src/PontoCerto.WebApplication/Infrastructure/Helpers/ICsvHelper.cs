namespace PontoCerto.WebApplication.Infrastructure.Helpers;

public interface ICsvHelper<T>
{
    List<T> GetRecords(IFormFile file);
}
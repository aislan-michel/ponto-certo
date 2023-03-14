namespace PontoCerto.WebApplication.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    public CustomErrorViewModel? CustomError { get; set; }
}

public class CustomErrorViewModel
{
    public CustomErrorViewModel(string title, string message)
    {
        Title = title;
        Message = message;
    }

    public string Title { get; private set; }
    public string Message { get; private set; }
}
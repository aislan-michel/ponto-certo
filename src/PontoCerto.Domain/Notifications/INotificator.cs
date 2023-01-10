namespace PontoCerto.Domain.Notifications;

public interface INotificator
{
    Dictionary<string, string> GetDictionary();
    void Add(string key, string message);
    bool HaveNotifications();
}
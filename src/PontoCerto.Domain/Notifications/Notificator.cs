namespace PontoCerto.Domain.Notifications;

public class Notificator : INotificator
{
    private readonly Dictionary<string, string> _notifications = new();

    public void Add(string key, string message)
    {
        _notifications.Add(key, message);
    }

    public Dictionary<string, string> GetDictionary()
    {
        return _notifications;
    }

    public bool HaveNotifications()
    {
        return _notifications.Any();
    }
}
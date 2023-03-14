namespace PontoCerto.Domain.Notifications;

public class Notificator : INotificator
{
    private readonly List<Notification> _notifications;

    public Notificator(List<Notification> notifications)
    {
        _notifications = notifications;
    }

    public List<Notification> Get()
    {
        return _notifications;
    }

    public Dictionary<string, string> GetDictionary()
    {
        return _notifications.ToDictionary(x => x.Key, x => x.Message);
    }

    public void Add(Notification notification)
    {
        _notifications.Add(notification);
    }

    public void AddRange(List<Notification> notifications)
    {
        
        _notifications.AddRange(notifications);
    }

    public bool HaveNotifications()
    {
        return _notifications.Any();
    }
}
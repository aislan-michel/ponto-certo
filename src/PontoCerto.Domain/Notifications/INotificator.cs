namespace PontoCerto.Domain.Notifications;

public interface INotificator
{
    List<Notification> Get();
    Dictionary<string, string> GetDictionary();
    void Add(Notification notification);
    void AddRange(List<Notification> notifications);
    bool HaveNotifications();
}
namespace Twitter_Clone.Entities;

public interface INotifiable
{
    void AddNotification(Guid notificationId);
}
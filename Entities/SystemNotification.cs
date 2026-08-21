namespace Twitter_Clone.Entities;

public sealed class SystemNotification : Notification
{
    public SystemNotification() : base("System")
    {
    }

    public void AddMessage(string message)
    {
        Message = message;
    }

    public override string GetMessage()
    {
        return $"System notification: {Message}";
    }
}

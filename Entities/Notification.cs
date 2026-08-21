namespace Twitter_Clone.Entities;

public abstract class Notification : BaseEntity
{
    private Guid _userId;
    private string _type = string.Empty;
    private string _message = string.Empty;
    private bool _isRead;

    public Notification(string notificationType)
    {
        Type = notificationType;
    }

    public Guid UserId
    {
        get => _userId;
        set => _userId = value;
    }

    public string Type
    {
        get => _type;
        set => _type = value;
    }

    public string Message
    {
        get => _message;
        protected set => _message = value;
    }

    public bool IsRead
    {
        get => _isRead;
        set => _isRead = value;
    }

    public abstract string GetMessage();
    
    
    public override string DescribeRecord()
    {
        var baseRecord = base.DescribeRecord();
        return $"{baseRecord}, UserId: {UserId}, Type: {Type}, Message: {Message}, IsRead: {IsRead}";
    }

    public string GetNotificationInfo()
    {
        return $"userId: {UserId}, type: {Type}";
    }
}

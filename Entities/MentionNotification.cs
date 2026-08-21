namespace Twitter_Clone.Entities;

public class MentionNotification : Notification
{
    public MentionNotification(Guid mentionedByUserId) : base("Mention")
    {
        MentionedByUserId = mentionedByUserId;
    }

    public Guid MentionedByUserId { get; set; }

    public void AddMessage(string message)
    {
        Message = message;
    }

    public override string DescribeRecord()
    {
        var baseRecord = base.DescribeRecord();
        return $"{MentionedByUserId} {baseRecord}";
    }

    public override string GetMessage()
    {
        return $"User with Id {MentionedByUserId} mentioned you: {Message}";
    }
}

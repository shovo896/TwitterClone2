namespace Twitter_Clone.Entities;

public class MentionNotification : Notification
{
    public MentionNotification(Guid mentionedByUserId) : base("Mention")
    {
        MentionedByUserId= mentionedByUserId;
    }
    
}
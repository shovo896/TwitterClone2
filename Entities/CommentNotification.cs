namespace Twitter_Clone.Entities;

public class CommentNotification : Notification
{
    public CommentNotification(Guid commentByUserId) : base("Comment")
    {
        CommentByUserId = commentByUserId;
    }

    public Guid CommentByUserId { get; set; }

    public void AddMessage(string message)
    {
        Message = message;
        
        
        
    }

    public override string DescribeRecord()
    {
        var baseRecord = base.DescribeRecord();
        return $"{baseRecord}, commentByUserId: {CommentByUserId}";
    }

    public override string GetMessage()
    {
        return $"User with Id {CommentByUserId} has comment {Message}";
    }
}

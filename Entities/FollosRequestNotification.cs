namespace Twitter_Clone.Entities;

public class FollosRequestNotification : Notification
{
    public FollosRequestNotification(Guid followRequestByUserId) : base("Follow Request")
    {
        FollowRequestByUserId = followRequestByUserId;
    }

    public Guid FollowRequestByUserId { get; set; }

    public void AddMessage(string message)
    {
        Message = message;
    }

    public override string GetMessage()
    {
        return $"User with Id {FollowRequestByUserId} sent a follow request: {Message}";
    }
}

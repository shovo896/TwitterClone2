using TwitterClone.Domain.Entities;

namespace Twitter_Clone.Entities;

public class LikeNotification : Notification
{
    public LikeNotification(Guid likeByUserId) : base("Like")
    {
        LikeByUserId = likeByUserId;
    }

    public Guid LikeByUserId { get; set; }
    public User? LikeByUser { get; set; }

    public void AddMessage(string message)
    {
        Message = message;
    }

    public override string DescribeRecord()
    { 
        var baseRecord = base.DescribeRecord(); 
        return $" {baseRecord}Notification Type:{Type} Message:{Message},IsRead:{IsRead},LikeByUserId:{LikeByUserId}";
    }
}
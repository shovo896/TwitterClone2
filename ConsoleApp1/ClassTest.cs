using Twitter_Clone.Entities;

namespace ConsoleApp1;

public class ClassTest
{
    public void Run()
    {
        BaseEntity likeNotification = new LikeNotification(Guid.NewGuid());
        var notifications = new List<Notification>()
        {
            new LikeNotification(Guid.NewGuid()),
            new CommentNotification(Guid.NewGuid()),
            new FriendRequestNotification(Guid.NewGuid()),
            new MentionNotification(Guid.NewGuid()),
            new SystemNotification()
        };
        
        foreach(var notification in notifications)
            {
            Console.WriteLine(notification.GetMessage());
            }
    }
}



namespace Twitter.Test
{
    public class ClassTest
    {
        public void Run()
        {
            var Tweet = new Tweet("Hello World!");
            Tweet.AddContent("This is mt content");
            ILikeable likeableTweet = new Tweet("This is another tweet");

        }
    }
}
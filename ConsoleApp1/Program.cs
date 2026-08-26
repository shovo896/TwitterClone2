using System;
using Twitter_Clone.Entities;
using TwitterClone.Domain.Entities;

var likeNotification = new LikeNotification(Guid.NewGuid());
likeNotification.AddMessage("your tweet");

var commentNotification = new CommentNotification(Guid.NewGuid());
commentNotification.AddMessage("Nice post!");

var followRequestNotification = new FollosRequestNotification(Guid.NewGuid());
followRequestNotification.AddMessage("Please accept my request.");

var mentionNotification = new MentionNotification(Guid.NewGuid());
mentionNotification.AddMessage("in a tweet");

var systemNotification = new SystemNotification();
systemNotification.AddMessage("Welcome to Twitter Clone.");

var maxTweetLength=Tweet.MaxContentLength;




var notifications = new List<Notification>
{
    likeNotification,
    commentNotification,
    followRequestNotification,
    mentionNotification,
    systemNotification
};

foreach (var notification in notifications)
{
    Console.WriteLine(notification.GetMessage());
}



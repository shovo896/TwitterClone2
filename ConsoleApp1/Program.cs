using System;
using Twitter_Clone.Entities;
using TwitterClone.Domain.Entities;

var notifications  = new List<Notification>();
foreach (var notification in notifications)
{
    new LikeNotification(Guid.NewGuid());
    new CommentNotification(Guid.NewGuid());
    new FollosRequestNotification(Guid.NewGuid());
    new MentionNotification(Guid.NewGuid());
    new SystemNotification();




};
//arr[0]=2
//arr[1]=3
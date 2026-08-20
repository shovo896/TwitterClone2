using Twitter_Clone.Entities;
using TwitterClone.Domain.Entities;
using Xunit;

namespace TwitterClone.Tests;

public class DomainEntityTests
{
    [Fact]
    public void BaseEntity_CreatesIdAndTimestamp()
    {
        var entity = new BaseEntity();

        Assert.NotEqual(Guid.Empty, entity.Id);
        Assert.True(entity.CreatedAt <= DateTime.UtcNow);
    }

    [Fact]
    public void BaseEntity_SetModified_UpdatesModifiedAt()
    {
        var entity = new BaseEntity();

        entity.SetModified();

        Assert.NotNull(entity.ModifiedAt);
        Assert.True(entity.ModifiedAt <= DateTime.UtcNow);
    }

    [Fact]
    public void Tweet_StoresContentAndUserId()
    {
        var user = new User();
        var tweet = new Tweet("Hello") { UserId = user.Id };

        Assert.Equal("Hello", tweet.Content);
        Assert.Equal(user.Id, tweet.UserId);
    }

    [Fact]
    public void LikeNotification_StoresLikeUserAndMessage()
    {
        var user = new User();
        var notification = new LikeNotification(user.Id);

        notification.AddMessage("Someone liked your tweet.");

        Assert.Equal("Like", notification.Type);
        Assert.Equal(user.Id, notification.LikeByUserId);
        Assert.Equal("Someone liked your tweet.", notification.Message);
    }

    [Fact]
    public void CommentNotification_StoresCommentUserAndMessage()
    {
        var user = new User();
        var notification = new CommentNotification(user.Id);

        notification.AddMessage("Someone commented on your tweet.");

        Assert.Equal("Comment", notification.Type);
        Assert.Equal(user.Id, notification.CommentByUserId);
        Assert.Equal("Someone commented on your tweet.", notification.Message);
    }
}

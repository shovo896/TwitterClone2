namespace Twitter_Clone.Entities;

public class Like
{
    private Guid _id;
    private Guid _userId;
    private Guid _tweetId;
    private DateTime _createdAt;
    private DateTime? _modifiedAt;
    private Guid _createBy;
    private Guid? _modifiedBy;

    public Like()
    {
        _id = Guid.NewGuid();
        _createdAt = DateTime.UtcNow;
    }

    public Guid Id
    {
        get { return _id; }
    }

    public Guid UserId
    {
        get { return _userId; }
        set { _userId = value; }
    }

    public Guid TweetId
    {
        get { return _tweetId; }
        set { _tweetId = value; }
    }

    public DateTime CreatedAt => _createdAt;
    public DateTime? ModifiedAt => _modifiedAt;
    public Guid CreatedBy => _createBy;
    public Guid? ModifiedBy => _modifiedBy;
}
namespace Twitter_Clone.Entities;

public interface Ifollowable
{
    void Follow(Guid userId);
    void Unfollow(Guid userId); 
}
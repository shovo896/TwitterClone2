namespace Twitter_Clone.Entities;

public class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? ModifiedAt { get; private set; }
    public Guid CreatedBy { get; private set; }
    public Guid? ModifiedBy { get; private set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public virtual string DescribeRecord()
    {
        return $"Id: {Id}, CreatedAt: {CreatedAt}, ModifiedAt: {ModifiedAt}, CreatedBy: {CreatedBy}, ModifiedBy: {ModifiedBy}";
    }

    public void SetModified()
    {
        ModifiedAt = DateTime.UtcNow;
    }
}

namespace Twitter_Clone.Entities;

public class Likeable
{
    public bool CanBeLiked(){
        return true;
    }

    public virtual string DescribeRecord()
    {
        return "hello";
    }
}
namespace Twitter_Clone.Entities;

public class SystemNotification :Notification
{
    public sealed class SystemNotification : Notification
    {
        public SystemNotification() : base('System')
        {
            
        }

        public void AddMessage(string message)
        {
            Message = message;
        }

        public override string DescribeRecord()
        {
            return base.DescribeRecord();
        }

        public override string GetMessage()
        {
                return $"{base.DescribeRecord()}, Message: {Message}";
        }
    }
    
}
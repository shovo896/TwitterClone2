using Twitter_Clone.Entities;

namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity,Ifollowable,INotifiable
    {
       private string _firstName = string.Empty;
       private string _lastName = string.Empty;
       private string _email = string.Empty;
       

       public User() : base(Guid.NewGuid())
       {
           
           
           
       }

     

       public string FirstName
       {
           get => _firstName;
           set => _firstName = value;
       }

       public string LastName
       {
           get => _lastName;
           set => _lastName = value;
       }

       public string Email
       {
           get => _email;
           set => _email = value;
       }

       private List<Guid> _followers=new List<Guid>();
       private List<Guid> _inComingNotifications=new List<Guid>();

       public void Follow(Guid userId)
       {
           if (!_followers.Contains(userId))
           {
               _followers.Add(userId);
           }
           
           
       }

       public void Unfollow(Guid userId)
       {
           if (_followers.Contains(userId))
           {
               _followers.Remove(userId);
           }
           
       }

       public void AddNotification(Guid notificationId)
       {
           if (!_inComingNotifications.Contains(notificationId))
           {
               _inComingNotifications.Add(notificationId);
           }
       }
       
       
    }
}

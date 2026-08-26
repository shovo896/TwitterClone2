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
    }
}

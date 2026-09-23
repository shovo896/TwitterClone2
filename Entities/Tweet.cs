using Twitter_Clone.Entities;

namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity,ILikeable
    {
        private Guid _userId;
        public const int MaxContentLength = 200;

        public Tweet(string content)
        {
           Content = content;
        }

        public Guid UserId
        {
           get => _userId;
           set => _userId = value;
        }

        public string Content { get; private set; }

        public void AddContent(Guid userId,string content)
        {
           UserId = userId;
           Content = string.IsNullOrEmpty(content) ? string.Empty : content;
        }

        public void AddContent(string content)
        {
           Content = string.IsNullOrEmpty(content) ? string.Empty : content;
        }

        public bool CanBeLiked()
        {
            return true; 
        }

        public bool CanBeLiked(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}

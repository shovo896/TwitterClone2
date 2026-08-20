using Twitter_Clone.Entities;

namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity
    {
        private Guid _userId;
        private string _content = string.Empty;

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

        public void AddContent(string content)
        {
           Content = string.IsNullOrEmpty(content) ? string.Empty : content;
        }
    }
}
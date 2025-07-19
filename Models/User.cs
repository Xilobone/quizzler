namespace Quizzler.Models
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.Empty;
        public string username { get; set; } = string.Empty;
        public string passwordHash { get; set; } = string.Empty;

        public static readonly User Empty = new User();
        public User()
        {
            Id = new Guid();
        }
    }
}
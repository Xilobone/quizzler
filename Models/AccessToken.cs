namespace Quizzler.Models
{
    public class AccessToken
    {
        public Guid Id { get; set; } = Guid.Empty;
        public User user { get; set; } = User.Empty;
        public string accessToken { get; set; } = string.Empty;
        public string refreshToken { get; set; } = string.Empty;
        public DateTime creationTime { get; set; } = DateTime.UnixEpoch;
        public int lifetime { get; set; } = 0;

    }
}
namespace Quizzler.DTO
{
    public class User
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string username { get; set; } = string.Empty;
    }
}
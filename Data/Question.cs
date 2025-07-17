namespace Quizzler.Data
{
    public class Question
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string prompt { get; set; } = string.Empty;
    }
}
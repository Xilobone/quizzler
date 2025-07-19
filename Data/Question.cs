namespace Quizzler.Data
{
    public abstract class Question
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string prompt { get; set; } = string.Empty;

        public string type { get; set; } = string.Empty;
        protected abstract string GetQuestionType();

        public void Process()
        {
            Id = new Guid();
            type = GetQuestionType();
        }
    }

    public class OpenQuestion : Question
    {
        public string answer { get; set; } = string.Empty;
        protected override string GetQuestionType() => "Open";

    }

    public class MultipleChoiceQuestion : Question
    {
        public string answer { get; set; } = string.Empty;
        public List<string> options { get; set; } = new List<string>();
        protected override string GetQuestionType() => "MultipleChoice";
    }

    public class BinaryQuestion : Question
    {
        public bool answer { get; set; } = false;
        protected override string GetQuestionType() => "Binary";
    }

    public class NumericQuestion : Question
    {
        public float answer { get; set; } = 0;
        public float lowerBound { get; set; } = 0;
        public float upperbound { get; set; } = 0;
        protected override string GetQuestionType() => "Numeric";
    }
}
namespace ThoughtHaven
{
    public class UserMessage
    {
        public string Message { get; }

        public UserMessage(string message)
        {
            this.Message = Guard.NullOrWhiteSpace(nameof(message), message);
        }

        public static implicit operator UserMessage(string message) => new UserMessage(message);
    }
}
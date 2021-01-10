namespace ThoughtHaven
{
    public class UiMessage
    {
        public string Message { get; }

        public UiMessage(string message)
        {
            this.Message = Guard.NullOrWhiteSpace(nameof(message), message);
        }

        public static implicit operator UiMessage(string message) => new UiMessage(message);
    }
}
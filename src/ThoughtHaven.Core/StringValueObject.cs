namespace ThoughtHaven
{
    public class StringValueObject : ValueObject<string>
    {
        public StringValueObject(string value) : base(value)
        {
            Guard.NullOrWhiteSpace(nameof(value), value);
        }
    }
}
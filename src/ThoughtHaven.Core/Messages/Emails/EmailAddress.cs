using System;

namespace ThoughtHaven.Messages.Emails
{
    public class EmailAddress : StringValueObject
    {
        public EmailAddress(string value) : base(value?.Trim().ToLower())
        {
            if (!value.Contains("@"))
            {
                throw new ArgumentException(
                    paramName: nameof(value),
                    message: $"The {nameof(value)} argument must contain an @ symbol.");
            }
        }

        public override string ToString() => this.Value;

        public static implicit operator EmailAddress(string value) => new EmailAddress(value);
    }
}
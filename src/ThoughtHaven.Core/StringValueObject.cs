using System;

namespace ThoughtHaven
{
    public class StringValueObject : ValueObject<string>
    {
        public StringValueObject(string value)
            : base(value)
        {
            Guard.NullOrWhiteSpace(nameof(value), value);
        }

        public StringValueObject(string value, string validCharacters)
            : this(value)
        {
            Guard.NullOrWhiteSpace(nameof(validCharacters), validCharacters);

            for (var i = 0; i < value.Length; i++)
            {
                if (validCharacters.IndexOf(value[i]) == -1)
                {
                    throw new ArgumentException(paramName: nameof(value),
                        message: $"Argument can only contain the following characters: '{validCharacters}'.");
                }
            }
        }
    }
}
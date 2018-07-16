using System;

namespace ThoughtHaven.Contacts
{
    public class LandAddress
    {
        public static LandAddress Parse(string address)
        {
            Guard.NullOrWhiteSpace(nameof(address), address);

            var parts = address.Split(new string[] { "," }, StringSplitOptions.None);

            if (parts.Length != 4)
            {
                throw new FormatException($"Invalid {nameof(LandAddress)} format. Correct format is '123 Fake Street, New York City, New York 10001, United States'.");
            }

            var streetAddress = parts[0].Trim();
            var city = parts[1].Trim();

            var lastSpaceInParts2 = parts[2].LastIndexOf(" ");
            var state = parts[2].Substring(0, lastSpaceInParts2).Trim();
            var postalCode = parts[2].Substring(lastSpaceInParts2).Trim();

            var country = parts[3].Trim();

            return new LandAddress(streetAddress, city, state, postalCode, country);
        }

        public string StreetAddress { get; }
        public string City { get; }
        public string State { get; }
        public string PostalCode { get; }
        public string Country { get; }

        public LandAddress(string streetAddress, string city, string state,
            string postalCode, string country)
        {
            this.StreetAddress = Guard.NullOrWhiteSpace(nameof(streetAddress),
                streetAddress);
            this.City = Guard.NullOrWhiteSpace(nameof(city), city);
            this.State = Guard.NullOrWhiteSpace(nameof(state), state);
            this.PostalCode = Guard.NullOrWhiteSpace(nameof(postalCode), postalCode);
            this.Country = Guard.NullOrWhiteSpace(nameof(country), country);
        }

        public override string ToString() =>
            $"{this.StreetAddress}, {this.City}, {this.State} {this.PostalCode}, {this.Country}";
    }
}
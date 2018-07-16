namespace ThoughtHaven.Commerce
{
    public class USD
    {
        public int Cents { get; }
        public string DisplayPrice => this.ToString().Replace(".00", string.Empty);

        public USD(int cents)
        {
            this.Cents = Guard.LessThan(nameof(cents), cents, minimum: 0);
        }

        public override string ToString()
        {
            var value = this.Cents.ToString();

            if (value.Length == 1) { return $"$0.0{value}"; }

            if (value.Length == 2) { return $"$0.{value}"; }

            var dollars = value.Substring(0, value.Length - 2);
            var cents = value.Substring(value.Length - 2);

            return $"${dollars}.{cents}";
        }

        public override int GetHashCode() => this.Cents.GetHashCode();

        public override bool Equals(object obj)
        {
            var usd = obj as USD;

            return usd != null ? this == usd : base.Equals(obj);
        }

        public static bool operator ==(USD x, USD y)
        {
            if (object.ReferenceEquals(x, y)) { return true; }

            if (((object)x == null) || ((object)y == null)) { return false; }

            return x.Cents == y.Cents;
        }

        public static bool operator !=(USD x, USD y) => !(x == y);
    }
}
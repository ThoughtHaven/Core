﻿namespace ThoughtHaven.Commerce
{
    public class Usd
    {
        public int Cents { get; }
        public string DisplayPrice => this.ToString().Replace(".00", string.Empty);

        public Usd(int cents)
        {
            this.Cents = Guard.LessThan(nameof(cents), cents, minimum: 0);
        }

        public override string ToString()
        {
            var value = this.Cents.ToString();

            if (value.Length == 1) { return $"$0.0{value}"; }

            if (value.Length == 2) { return $"$0.{value}"; }

            var dollars = value[0..^2];
            var cents = value[^2..];

            return $"${dollars}.{cents}";
        }

        public override int GetHashCode() => System.HashCode.Combine(this.Cents);

        public override bool Equals(object? obj)
        {
            var usd = obj as Usd;

            return usd is not null ? this == usd : base.Equals(obj);
        }

        public static bool operator ==(Usd x, Usd y)
        {
            if (ReferenceEquals(x, y)) { return true; }

            if ((x is null) || (y is null)) { return false; }

            return x.Cents == y.Cents;
        }

        public static bool operator !=(Usd x, Usd y) => !(x == y);
    }
}
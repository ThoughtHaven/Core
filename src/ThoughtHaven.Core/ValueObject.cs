using System;
using System.Collections.Generic;

namespace ThoughtHaven
{
    public class ValueObject<T> : IEquatable<ValueObject<T>>
    {
        public T Value { get; }

        public ValueObject(T value) { this.Value = Guard.Null(nameof(value), value); }

        public override int GetHashCode() => this.Value!.GetHashCode();

        public override bool Equals(object obj) => Equals(this, obj as ValueObject<T>);

        public virtual bool Equals(ValueObject<T> other) => Equals(this, other);

        public static bool operator ==(ValueObject<T>? x, ValueObject<T>? y) => Equals(x, y);

        protected static bool Equals(ValueObject<T>? x, ValueObject<T>? y)
        {
            if (ReferenceEquals(x, y)) { return true; }

            if ((x is null) || (y is null)) { return false; }

            return EqualityComparer<T>.Default.Equals(x.Value, y.Value);
        }

        public static bool operator !=(ValueObject<T>? x, ValueObject<T>? y) => !(x == y);
    }
}
namespace ThoughtHaven
{
    public class Result<TValue, TFailure> : Result<TFailure>
    {
        public TValue Value { get; }

        public Result(TValue value) : this(success: true, value: value) { }

        public Result(TFailure failure)
            : base(failure)
        {
            this.Value = default!;
        }

        protected Result(bool success, TValue value)
            : base(success)
        {
            this.Value = Guard.Null(nameof(value), value);
        }

        public static implicit operator Result<TValue, TFailure>(TValue value) =>
            new Result<TValue, TFailure>(value);

        public static implicit operator Result<TValue, TFailure>(TFailure failure) =>
            new Result<TValue, TFailure>(failure);
    }
}
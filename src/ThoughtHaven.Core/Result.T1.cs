namespace ThoughtHaven
{
    public class Result<TFailure>
    {
        public bool Success { get; }
        public TFailure Failure { get; }

        public Result() : this(success: true) { }

        public Result(TFailure failure) : this(success: false)
        {
            this.Failure = Guard.Null(nameof(failure), failure);
        }

        protected Result(bool success)
        {
            this.Success = success;
            this.Failure = default(TFailure);
        }

        public static implicit operator Result<TFailure>(TFailure failure) =>
            new Result<TFailure>(failure);
    }
}
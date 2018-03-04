using System;
using Xunit;

namespace ThoughtHaven
{
    public partial class ResultTests
    {
        public class T1
        {
            public class Constructor
            {
                public class EmptyOverload
                {
                    [Fact]
                    public void WhenCalled_Succeeds()
                    {
                        var result = new Result<object>();

                        Assert.True(result.Success);
                    }

                    [Fact]
                    public void WhenCalled_DefaultsFailure()
                    {
                        var result = new Result<object>();

                        Assert.Null(result.Failure);
                    }
                }

                public class FailureOverload
                {
                    [Fact]
                    public void NullFailure_Throws()
                    {
                        Assert.Throws<ArgumentNullException>("failure", () =>
                        {
                            new Result<object>(failure: null);
                        });
                    }

                    [Fact]
                    public void NotNullFailure_DoesNotSucceed()
                    {
                        var failure = new object();
                        var result = new Result<object>(failure);

                        Assert.False(result.Success);
                    }

                    [Fact]
                    public void NotNullFailure_SetsFailure()
                    {
                        var failure = new object();
                        var result = new Result<object>(failure);

                        Assert.Equal(failure, result.Failure);
                    }
                }
            }

            public class ResultOperator
            {
                public class FailureOverload
                {
                    [Fact]
                    public void NullFailure_Throws()
                    {
                        string nullFailure = null;

                        Assert.Throws<ArgumentNullException>("failure", () =>
                        {
                            Result<object> result = nullFailure;
                        });
                    }

                    [Fact]
                    public void ValidFailure_DoesNotSucceed()
                    {
                        var failure = new object();
                        Result<object> result = failure;

                        Assert.False(result.Success);
                    }

                    [Fact]
                    public void ValidFailure_SetsFailure()
                    {
                        var failure = new object();
                        Result<object> result = failure;

                        Assert.Equal(failure, result.Failure);
                    }
                }
            }
        }
    }
}
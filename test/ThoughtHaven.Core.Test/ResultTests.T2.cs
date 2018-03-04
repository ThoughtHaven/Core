using System;
using Xunit;

namespace ThoughtHaven
{
    public partial class ResultTests
    {
        public class T2
        {
            public class Type
            {
                [Fact]
                public void InheritsResult()
                {
                    Assert.True(typeof(Result<object>).IsAssignableFrom(
                        typeof(Result<object, object>)));
                }
            }

            public class Constructor
            {
                public class ValueOverload
                {
                    [Fact]
                    public void NullValue_Throws()
                    {
                        Assert.Throws<ArgumentNullException>("value", () =>
                        {
                            new Result<string, object>(value: null);
                        });
                    }

                    [Fact]
                    public void ValidValue_Succeeds()
                    {
                        var value = new object();
                        var result = new Result<object, object>(value: value);

                        Assert.True(result.Success);
                    }

                    [Fact]
                    public void ValidValue_SetsValue()
                    {
                        var value = new object();
                        var result = new Result<object, object>(value: value);

                        Assert.Equal(value, result.Value);
                    }

                    [Fact]
                    public void ValidValue_DefaultsFailure()
                    {
                        var value = new object();
                        var result = new Result<object, object>(value: value);

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
                            new Result<string, object>(failure: null);
                        });
                    }

                    [Fact]
                    public void ValidFailure_DoesNotSucceed()
                    {
                        var failure = new object();
                        var result = new Result<object, object>(failure: failure);

                        Assert.False(result.Success);
                    }

                    [Fact]
                    public void ValidFailure_DefaultsValue()
                    {
                        var failure = new object();
                        var result = new Result<object, object>(failure: failure);

                        Assert.Equal(default(object), result.Value);
                    }

                    [Fact]
                    public void ValidFailure_SetsFailure()
                    {
                        var failure = new object();
                        var result = new Result<object, object>(failure: failure);

                        Assert.Equal(failure, result.Failure);
                    }
                }
            }

            public class ResultOperator
            {
                public class ValueOverload
                {
                    [Fact]
                    public void NullValue_Throws()
                    {
                        Assert.Throws<ArgumentNullException>("value", () =>
                        {
                            Result<string, object> result = (string)null;
                        });
                    }

                    [Fact]
                    public void ValidValue_Succeeds()
                    {
                        var value = new object();
                        Result<object, Exception> result = value;

                        Assert.True(result.Success);
                    }

                    [Fact]
                    public void ValidValue_SetsValue()
                    {
                        var value = new object();
                        Result<object, Exception> result = value;

                        Assert.Equal(value, result.Value);
                    }

                    [Fact]
                    public void ValidValue_DefaultsFailure()
                    {
                        var value = new object();
                        Result<object, Exception> result = value;

                        Assert.Equal(default(Exception), result.Failure);
                    }
                }

                public class FailureOverload
                {
                    [Fact]
                    public void NullFailure_Throws()
                    {
                        Assert.Throws<ArgumentNullException>("failure", () =>
                        {
                            Result<string, object> result = (object)null;
                        });
                    }

                    [Fact]
                    public void ValidFailure_DoesNotSucceed()
                    {
                        var failure = new Exception();
                        Result<object, Exception> result = failure;

                        Assert.False(result.Success);
                    }

                    [Fact]
                    public void ValidFailure_DefaultsValue()
                    {
                        var failure = new Exception();
                        Result<object, Exception> result = failure;

                        Assert.Equal(default(object), result.Value);
                    }

                    [Fact]
                    public void ValidFailure_SetsFailure()
                    {
                        var failure = new Exception();
                        Result<object, Exception> result = failure;

                        Assert.Equal(failure, result.Failure);
                    }
                }
            }
        }
    }
}
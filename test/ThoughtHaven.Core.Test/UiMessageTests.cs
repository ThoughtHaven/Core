using System;
using Xunit;

namespace ThoughtHaven
{
    public class UiMessageTests
    {
        public class Constructor
        {
            public class MessageOverload
            {
                [Fact]
                public void NullMessage_Throws()
                {
                    Assert.Throws<ArgumentNullException>("message", () =>
                    {
                        new UiMessage(message: null!);
                    });
                }

                [Fact]
                public void EmptyMessage_Throws()
                {
                    Assert.Throws<ArgumentException>("message", () =>
                    {
                        new UiMessage(message: "");
                    });
                }

                [Fact]
                public void WhiteSpaceMessage_Throws()
                {
                    Assert.Throws<ArgumentException>("message", () =>
                    {
                        new UiMessage(message: " ");
                    });
                }

                [Fact]
                public void ValidMessage_SetsMessage()
                {
                    var message = "Expected message.";

                    var userMessage = new UiMessage(message);

                    Assert.Equal(message, userMessage.Message);
                }
            }
        }

        public class UserMessageOperator
        {
            public class StringOverload
            {
                [Fact]
                public void NullMessage_Throws()
                {
                    string? message = null;

                    Assert.Throws<ArgumentNullException>("message", () =>
                    {
                        UiMessage result = message!;
                    });
                }

                [Fact]
                public void EmptyMessage_Throws()
                {
                    string message = "";

                    Assert.Throws<ArgumentException>("message", () =>
                    {
                        UiMessage result = message;
                    });
                }

                [Fact]
                public void WhiteSpaceMessage_Throws()
                {
                    string message = " ";

                    Assert.Throws<ArgumentException>("message", () =>
                    {
                        UiMessage result = message;
                    });
                }

                [Fact]
                public void ValidMessage_SetsMessage()
                {
                    var message = "Expected message.";

                    UiMessage userMessage = message;

                    Assert.Equal(message, userMessage.Message);
                }
            }
        }
    }
}
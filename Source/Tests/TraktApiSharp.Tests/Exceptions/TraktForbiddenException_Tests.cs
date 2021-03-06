﻿namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Traits;
    using TraktApiSharp.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktForbiddenException_Tests
    {
        [Fact]
        public void Test_TraktForbiddenException_DefaultConstructor()
        {
            var exception = new TraktForbiddenException();

            exception.Message.Should().Be("Forbidden - invalid API key or unapproved app");
            exception.StatusCode.Should().Be(HttpStatusCode.Forbidden);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktForbiddenException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktForbiddenException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(HttpStatusCode.Forbidden);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}

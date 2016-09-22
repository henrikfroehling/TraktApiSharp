﻿namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentPostRequestTests
    {
        [TestMethod]
        public void TestATraktNoContentPostRequestIsAbstract()
        {
            typeof(ATraktNoContentPostRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentPostRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentPostRequest<float>).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentPostRequestHasGenericTypeParameter()
        {
            typeof(ATraktNoContentPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktNoContentPostRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktNoContentPostRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktNoContentPostRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktNoContentPostRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktNoContentPostRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}

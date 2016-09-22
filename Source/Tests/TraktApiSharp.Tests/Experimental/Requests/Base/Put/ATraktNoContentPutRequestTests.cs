﻿namespace TraktApiSharp.Tests.Experimental.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentPutRequestTests
    {
        [TestMethod]
        public void TestATraktNoContentPutRequestIsAbstract()
        {
            typeof(ATraktNoContentPutRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentPutRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentPutRequest<float>).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentPutRequestHasGenericTypeParameter()
        {
            typeof(ATraktNoContentPutRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktNoContentPutRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktNoContentPutRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktNoContentPutRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktNoContentPutRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktNoContentPutRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}

namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktCertificationsModuleTests
    {
        [TestMethod]
        public void TestTraktCertificationsModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktCertificationsModule)).Should().BeTrue();
        }

        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            TestUtility.SetupMockHttpClient();
        }

        [ClassCleanup]
        public static void CleanupTests()
        {
            TestUtility.ResetMockHttpClient();
        }

        [TestCleanup]
        public void CleanupSingleTest()
        {
            TestUtility.ClearMockHttpClient();
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieCertifications

        [TestMethod]
        public void TestTraktCertificationsModuleGetMovieCertifications()
        {
            var certifications = TestUtility.ReadFileContents(@"Objects\Basic\Certifications.json");
            certifications.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithoutOAuth("certifications/movies", certifications);

            var response = TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync().Result;

            response.Should().NotBeNull();
            response.US.Should().NotBeNull().And.HaveCount(5);

            var usCertifications = response.US.ToArray();

            usCertifications[0].Should().NotBeNull();
            usCertifications[0].Name.Should().Be("G");
            usCertifications[0].Slug.Should().Be("g");
            usCertifications[0].Description.Should().Be("All Ages");

            usCertifications[1].Should().NotBeNull();
            usCertifications[1].Name.Should().Be("PG");
            usCertifications[1].Slug.Should().Be("pg");
            usCertifications[1].Description.Should().Be("Parental Guidance Suggested");

            usCertifications[2].Should().NotBeNull();
            usCertifications[2].Name.Should().Be("PG-13");
            usCertifications[2].Slug.Should().Be("pg-13");
            usCertifications[2].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");

            usCertifications[3].Should().NotBeNull();
            usCertifications[3].Name.Should().Be("R");
            usCertifications[3].Slug.Should().Be("r");
            usCertifications[3].Description.Should().Be("Mature Audiences - Ages 17+ Recommended");

            usCertifications[4].Should().NotBeNull();
            usCertifications[4].Name.Should().Be("Not Rated");
            usCertifications[4].Slug.Should().Be("nr");
            usCertifications[4].Description.Should().Be("Not Rated");
        }

        [TestMethod]
        public void TestTraktCertificationsModuleGetMovieCertificationsExceptions()
        {
            var uri = "certifications/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktCertifications>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Certifications.GetMovieCertificationsAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieCertifications

        [TestMethod]
        public void TestTraktCertificationsModuleGetShowCertifications()
        {
            var certifications = TestUtility.ReadFileContents(@"Objects\Basic\Certifications.json");
            certifications.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithoutOAuth("certifications/shows", certifications);

            var response = TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync().Result;

            response.Should().NotBeNull();
            response.US.Should().NotBeNull().And.HaveCount(5);

            var usCertifications = response.US.ToArray();

            usCertifications[0].Should().NotBeNull();
            usCertifications[0].Name.Should().Be("G");
            usCertifications[0].Slug.Should().Be("g");
            usCertifications[0].Description.Should().Be("All Ages");

            usCertifications[1].Should().NotBeNull();
            usCertifications[1].Name.Should().Be("PG");
            usCertifications[1].Slug.Should().Be("pg");
            usCertifications[1].Description.Should().Be("Parental Guidance Suggested");

            usCertifications[2].Should().NotBeNull();
            usCertifications[2].Name.Should().Be("PG-13");
            usCertifications[2].Slug.Should().Be("pg-13");
            usCertifications[2].Description.Should().Be("Parents Strongly Cautioned - Ages 13+ Recommended");

            usCertifications[3].Should().NotBeNull();
            usCertifications[3].Name.Should().Be("R");
            usCertifications[3].Slug.Should().Be("r");
            usCertifications[3].Description.Should().Be("Mature Audiences - Ages 17+ Recommended");

            usCertifications[4].Should().NotBeNull();
            usCertifications[4].Name.Should().Be("Not Rated");
            usCertifications[4].Slug.Should().Be("nr");
            usCertifications[4].Description.Should().Be("Not Rated");
        }

        [TestMethod]
        public void TestTraktCertificationsModuleGetShowCertificationsExceptions()
        {
            var uri = "certifications/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktCertifications>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Certifications.GetShowCertificationsAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion
    }
}

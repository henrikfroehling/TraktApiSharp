namespace TraktApiSharp.Tests.Objects.Basic
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktCertificationsTests
    {
        [TestMethod]
        public void TestTraktCertificationsDefaultConstructor()
        {
            var certifications = new TraktCertifications();

            certifications.US.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCertificationsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Certifications.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var certifications = JsonConvert.DeserializeObject<TraktCertifications>(jsonFile);

            certifications.Should().NotBeNull();
            certifications.US.Should().NotBeNull().And.HaveCount(5);

            var usCertifications = certifications.US.ToArray();

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
    }
}

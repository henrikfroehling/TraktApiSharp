namespace TraktApiSharp.Tests.Objects.Basic
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktCertificationTests
    {
        [TestMethod]
        public void TestTraktCertificationDefaultConstructor()
        {
            var certification = new TraktCertification();

            certification.Name.Should().BeNullOrEmpty();
            certification.Slug.Should().BeNullOrEmpty();
            certification.Description.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktCertificationReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Certification.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var certification = JsonConvert.DeserializeObject<TraktCertification>(jsonFile);

            certification.Should().NotBeNull();
            certification.Name.Should().Be("PG");
            certification.Slug.Should().Be("pg");
            certification.Description.Should().Be("Parental Guidance Suggested");
        }
    }
}

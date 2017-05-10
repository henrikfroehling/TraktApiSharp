namespace TraktApiSharp.Tests.Objects.Basic
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktNetworkTests
    {
        [TestMethod]
        public void TestTraktNetworkDefaultConstructor()
        {
            var network = new TraktNetwork();

            network.Name.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktNetworkReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Network.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var network = JsonConvert.DeserializeObject<TraktNetwork>(jsonFile);

            network.Should().NotBeNull();
            network.Name.Should().Be("ABC (US)");
        }
    }
}

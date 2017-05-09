namespace TraktApiSharp.Tests.Objects.Post.Users.HiddenItems.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Users.HiddenItems.Responses;
    using Utils;

    [TestClass]
    public class TraktUserHiddenItemsPostResponseTests
    {
        [TestMethod]
        public void TestTraktUserHiddenItemsPostResponseDefaultConstructor()
        {
            var hiddenItemsPostResponse = new TraktUserHiddenItemsPostResponse();

            hiddenItemsPostResponse.Added.Should().BeNull();
            hiddenItemsPostResponse.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserHiddenItemsPostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Users\HiddenItems\Responses\UserHiddenItemsPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var hiddenItemsPostResponse = JsonConvert.DeserializeObject<TraktUserHiddenItemsPostResponse>(jsonFile);

            hiddenItemsPostResponse.Should().NotBeNull();

            hiddenItemsPostResponse.Added.Should().NotBeNull();
            hiddenItemsPostResponse.Added.Movies.Should().Be(1);
            hiddenItemsPostResponse.Added.Shows.Should().Be(2);
            hiddenItemsPostResponse.Added.Seasons.Should().Be(2);

            hiddenItemsPostResponse.NotFound.Should().NotBeNull();
            hiddenItemsPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = hiddenItemsPostResponse.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            hiddenItemsPostResponse.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            hiddenItemsPostResponse.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
        }
    }
}

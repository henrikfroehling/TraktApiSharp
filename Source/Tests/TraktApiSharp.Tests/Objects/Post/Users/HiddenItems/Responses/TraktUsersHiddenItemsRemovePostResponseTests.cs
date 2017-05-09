namespace TraktApiSharp.Tests.Objects.Post.Users.HiddenItems.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Users.HiddenItems.Responses;
    using Utils;

    [TestClass]
    public class TraktUsersHiddenItemsRemovePostResponseTests
    {
        [TestMethod]
        public void TestTraktUsersHiddenItemsRemovePostResponseDefaultConstructor()
        {
            var hiddenItemsRemovePost = new TraktUsersHiddenItemsRemovePostResponse();

            hiddenItemsRemovePost.Deleted.Should().BeNull();
            hiddenItemsRemovePost.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUsersHiddenItemsRemovePostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Users\HiddenItems\Responses\UsersHiddenItemsRemovePostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var hiddenItemsRemovePost = JsonConvert.DeserializeObject<TraktUsersHiddenItemsRemovePostResponse>(jsonFile);

            hiddenItemsRemovePost.Should().NotBeNull();

            hiddenItemsRemovePost.Deleted.Should().NotBeNull();
            hiddenItemsRemovePost.Deleted.Movies.Should().Be(1);
            hiddenItemsRemovePost.Deleted.Shows.Should().Be(2);
            hiddenItemsRemovePost.Deleted.Seasons.Should().Be(2);

            hiddenItemsRemovePost.NotFound.Should().NotBeNull();
            hiddenItemsRemovePost.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = hiddenItemsRemovePost.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            hiddenItemsRemovePost.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            hiddenItemsRemovePost.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
        }
    }
}

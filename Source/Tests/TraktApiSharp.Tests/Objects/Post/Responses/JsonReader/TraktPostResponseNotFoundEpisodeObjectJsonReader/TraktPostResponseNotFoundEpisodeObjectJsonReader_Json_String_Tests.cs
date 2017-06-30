﻿namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktPostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktPostResponseNotFoundEpisodeObjectJsonReader();

            var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            postResponseNotFoundEpisode.Should().NotBeNull();
            postResponseNotFoundEpisode.Ids.Should().NotBeNull();
            postResponseNotFoundEpisode.Ids.Trakt.Should().Be(73640U);
            postResponseNotFoundEpisode.Ids.Tvdb.Should().Be(3254641U);
            postResponseNotFoundEpisode.Ids.Imdb.Should().Be("tt1480055");
            postResponseNotFoundEpisode.Ids.Tmdb.Should().Be(63056U);
            postResponseNotFoundEpisode.Ids.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new TraktPostResponseNotFoundEpisodeObjectJsonReader();

            var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            postResponseNotFoundEpisode.Should().NotBeNull();
            postResponseNotFoundEpisode.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktPostResponseNotFoundEpisodeObjectJsonReader();

            var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(default(string));
            postResponseNotFoundEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktPostResponseNotFoundEpisodeObjectJsonReader();

            var postResponseNotFoundEpisode = await jsonReader.ReadObjectAsync(string.Empty);
            postResponseNotFoundEpisode.Should().BeNull();
        }
    }
}

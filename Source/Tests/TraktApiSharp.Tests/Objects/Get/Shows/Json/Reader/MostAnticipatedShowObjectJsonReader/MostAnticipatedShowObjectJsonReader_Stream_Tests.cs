﻿namespace TraktApiSharp.Tests.Objects.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class MostAnticipatedShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new MostAnticipatedShowObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktMostAnticipatedShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().Be(12805);
                traktMostAnticipatedShow.Show.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostAnticipatedShow.Show.Year.Should().Be(2011);
                traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new MostAnticipatedShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktMostAnticipatedShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().Be(12805);
                traktMostAnticipatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new MostAnticipatedShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktMostAnticipatedShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().BeNull();
                traktMostAnticipatedShow.Show.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostAnticipatedShow.Show.Year.Should().Be(2011);
                traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new MostAnticipatedShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktMostAnticipatedShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().BeNull();
                traktMostAnticipatedShow.Show.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostAnticipatedShow.Show.Year.Should().Be(2011);
                traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new MostAnticipatedShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktMostAnticipatedShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().Be(12805);
                traktMostAnticipatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new MostAnticipatedShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktMostAnticipatedShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().BeNull();
                traktMostAnticipatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new MostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktMostAnticipatedShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new MostAnticipatedShowObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktMostAnticipatedShow = await traktJsonReader.ReadObjectAsync(stream);
                traktMostAnticipatedShow.Should().BeNull();
            }
        }
    }
}

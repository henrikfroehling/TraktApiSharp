﻿namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserSeasonsStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSeasonsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().Be(6);
                userSeasonsStatistics.Comments.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSeasonsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().BeNull();
                userSeasonsStatistics.Comments.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSeasonsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().Be(6);
                userSeasonsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSeasonsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().BeNull();
                userSeasonsStatistics.Comments.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSeasonsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().Be(6);
                userSeasonsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSeasonsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().BeNull();
                userSeasonsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserSeasonsStatisticsObjectJsonReader();

            var userSeasonsStatistics = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userSeasonsStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userSeasonsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);
                userSeasonsStatistics.Should().BeNull();
            }
        }
    }
}

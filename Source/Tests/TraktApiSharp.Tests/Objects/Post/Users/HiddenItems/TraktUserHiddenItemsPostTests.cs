namespace TraktApiSharp.Tests.Objects.Post.Users.HiddenItems
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using TraktApiSharp.Objects.Post.Users.HiddenItems;

    [TestClass]
    public class TraktUserHiddenItemsPostTests
    {
        [TestMethod]
        public void TestTraktUserHiddenItemsPostDefaultConstructor()
        {
            var hiddenItems = new TraktUsersHiddenItemsPost();

            hiddenItems.Movies.Should().BeNull();
            hiddenItems.Shows.Should().BeNull();
            hiddenItems.Seasons.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserHiddenItemsPostWriteJson()
        {
            var hiddenItems = new TraktUsersHiddenItemsPost
            {
                Movies = new List<TraktUsersHiddenItemsPostMovie>()
                {
                    new TraktUsersHiddenItemsPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktUsersHiddenItemsPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktUsersHiddenItemsPostShow>()
                {
                    new TraktUsersHiddenItemsPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktUsersHiddenItemsPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktUsersHiddenItemsPostShowSeason>()
                        {
                            new TraktUsersHiddenItemsPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktUsersHiddenItemsPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktUsersHiddenItemsPostShowSeason>()
                        {
                            new TraktUsersHiddenItemsPostShowSeason
                            {
                                Number = 1
                            }
                        }
                    }
                },
                Seasons = new List<TraktUsersHiddenItemsPostSeason>()
                {
                    new TraktUsersHiddenItemsPostSeason
                    {
                        Ids = new TraktSeasonIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var strJson = JsonConvert.SerializeObject(hiddenItems);

            strJson.Should().NotBeNullOrEmpty();

            var hiddenItemsPostFromJson = JsonConvert.DeserializeObject<TraktUsersHiddenItemsPost>(strJson);

            hiddenItemsPostFromJson.Should().NotBeNull();

            hiddenItemsPostFromJson.Movies.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPostFromJson.Shows.Should().NotBeNull().And.HaveCount(3);
            hiddenItemsPostFromJson.Seasons.Should().NotBeNull().And.HaveCount(1);

            var movies = hiddenItemsPostFromJson.Movies.ToArray();
            
            movies[0].Title.Should().Be("Batman Begins");
            movies[0].Year.Should().Be(2005);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(1U);
            movies[0].Ids.Slug.Should().Be("batman-begins-2005");
            movies[0].Ids.Imdb.Should().Be("tt0372784");
            movies[0].Ids.Tmdb.Should().Be(272U);
            
            movies[1].Title.Should().BeNullOrEmpty();
            movies[1].Year.Should().NotHaveValue();
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(0U);
            movies[1].Ids.Slug.Should().BeNullOrEmpty();
            movies[1].Ids.Imdb.Should().Be("tt0000111");
            movies[1].Ids.Tmdb.Should().BeNull();

            var shows = hiddenItemsPostFromJson.Shows.ToArray();
            
            shows[0].Title.Should().Be("Breaking Bad");
            shows[0].Year.Should().Be(2008);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("breaking-bad");
            shows[0].Ids.Tvdb.Should().Be(81189U);
            shows[0].Ids.Imdb.Should().Be("tt0903747");
            shows[0].Ids.Tmdb.Should().Be(1396U);
            shows[0].Ids.TvRage.Should().Be(18164U);
            shows[0].Seasons.Should().BeNull();
            
            shows[1].Title.Should().Be("The Walking Dead");
            shows[1].Year.Should().Be(2010);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(2U);
            shows[1].Ids.Slug.Should().Be("the-walking-dead");
            shows[1].Ids.Tvdb.Should().Be(153021U);
            shows[1].Ids.Imdb.Should().Be("tt1520211");
            shows[1].Ids.Tmdb.Should().Be(1402U);
            shows[1].Ids.TvRage.Should().Be(25056U);
            shows[1].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show2Seasons = shows[1].Seasons.ToArray();
            
            show2Seasons[0].Number.Should().Be(3);
            
            shows[2].Title.Should().Be("Mad Men");
            shows[2].Year.Should().Be(2007);
            shows[2].Ids.Should().NotBeNull();
            shows[2].Ids.Trakt.Should().Be(4U);
            shows[2].Ids.Slug.Should().Be("mad-men");
            shows[2].Ids.Tvdb.Should().Be(80337U);
            shows[2].Ids.Imdb.Should().Be("tt0804503");
            shows[2].Ids.Tmdb.Should().Be(1104U);
            shows[2].Ids.TvRage.Should().Be(16356U);
            shows[2].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show3Seasons = shows[2].Seasons.ToArray();
            
            show3Seasons[0].Number.Should().Be(1);

            var seassons = hiddenItemsPostFromJson.Seasons.ToArray();
            
            seassons[0].Ids.Should().NotBeNull();
            seassons[0].Ids.Trakt.Should().Be(1061U);
            seassons[0].Ids.Tvdb.Should().Be(1555111U);
            seassons[0].Ids.Tmdb.Should().Be(422183U);
            seassons[0].Ids.TvRage.Should().Be(12345U);
        }
    }
}

namespace TraktApiSharp.Tests.Objects.Post.Users.HiddenItems
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using TraktApiSharp.Objects.Post.Users.HiddenItems;

    [TestClass]
    public class TraktUserHiddenItemsPostBuilderTests
    {
        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddMovie()
        {
            var movie1 = new TraktMovie
            {
                Title = "movie1",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie1",
                    Imdb = "imdb1",
                    Tmdb = 1234
                }
            };

            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Calendar);

            builder.AddMovie(movie1);

            var hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            builder.AddMovie(movie1);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            movie1.Ids.Trakt = 2;

            builder.AddMovie(movie1);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = hiddenItemsPost.Movies.ToArray();

            movies[0].Should().NotBeNull();
            movies[0].Title.Should().Be("movie1");
            movies[0].Year.Should().Be(2016);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(2U);
            movies[0].Ids.Slug.Should().Be("movie1");
            movies[0].Ids.Imdb.Should().Be("imdb1");
            movies[0].Ids.Tmdb.Should().Be(1234U);

            var movie2 = new TraktMovie
            {
                Title = "movie2",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 3,
                    Slug = "movie2",
                    Imdb = "imdb2",
                    Tmdb = 12345
                }
            };

            builder.AddMovie(movie2);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            movies = hiddenItemsPost.Movies.ToArray();

            movies[0].Should().NotBeNull();
            movies[0].Title.Should().Be("movie1");
            movies[0].Year.Should().Be(2016);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(2U);
            movies[0].Ids.Slug.Should().Be("movie1");
            movies[0].Ids.Imdb.Should().Be("imdb1");
            movies[0].Ids.Tmdb.Should().Be(1234U);

            movies[1].Should().NotBeNull();
            movies[1].Title.Should().Be("movie2");
            movies[1].Year.Should().Be(2016);
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(3U);
            movies[1].Ids.Slug.Should().Be("movie2");
            movies[1].Ids.Imdb.Should().Be("imdb2");
            movies[1].Ids.Tmdb.Should().Be(12345U);
        }

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddMovieArgumentExceptions()
        {
            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Calendar);

            Action act = () => builder.AddMovie(null);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddMovie(new TraktMovie());
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds() });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 }, Year = 123 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 }, Year = 12345 });
            act.ShouldThrow<ArgumentException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddMoviesCollection()
        {
            var movie1 = new TraktMovie
            {
                Title = "movie1",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie1",
                    Imdb = "imdb1",
                    Tmdb = 1234
                }
            };

            var movie2 = new TraktMovie
            {
                Title = "movie2",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 3,
                    Slug = "movie2",
                    Imdb = "imdb2",
                    Tmdb = 12345
                }
            };

            var movies = new List<TraktMovie>
            {
                movie1,
                movie2
            };

            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Calendar);

            builder.AddMovies(movies);

            var hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            builder.AddMovies(movies);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            movie1.Ids.Trakt = 2;

            movies = new List<TraktMovie>
            {
                movie1,
                movie2
            };

            builder.AddMovies(movies);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            var historyMovies = hiddenItemsPost.Movies.ToArray();

            historyMovies[0].Should().NotBeNull();
            historyMovies[0].Title.Should().Be("movie1");
            historyMovies[0].Year.Should().Be(2016);
            historyMovies[0].Ids.Should().NotBeNull();
            historyMovies[0].Ids.Trakt.Should().Be(2U);
            historyMovies[0].Ids.Slug.Should().Be("movie1");
            historyMovies[0].Ids.Imdb.Should().Be("imdb1");
            historyMovies[0].Ids.Tmdb.Should().Be(1234U);

            historyMovies[1].Should().NotBeNull();
            historyMovies[1].Title.Should().Be("movie2");
            historyMovies[1].Year.Should().Be(2016);
            historyMovies[1].Ids.Should().NotBeNull();
            historyMovies[1].Ids.Trakt.Should().Be(3U);
            historyMovies[1].Ids.Slug.Should().Be("movie2");
            historyMovies[1].Ids.Imdb.Should().Be("imdb2");
            historyMovies[1].Ids.Tmdb.Should().Be(12345U);
        }

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddMoviesCollectionArgumentExceptions()
        {
            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Calendar);

            Action act = () => builder.AddMovies(null);
            act.ShouldThrow<ArgumentNullException>();

            var movies = new List<TraktMovie>
            {
                new TraktMovie()
            };

            act = () => builder.AddMovies(movies);
            act.ShouldThrow<ArgumentNullException>();

            movies = new List<TraktMovie>
            {
                new TraktMovie { Ids = new TraktMovieIds() }
            };

            act = () => builder.AddMovies(movies);
            act.ShouldThrow<ArgumentException>();

            movies = new List<TraktMovie>
            {
                new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 }, Year = 123 }
            };

            act = () => builder.AddMovies(movies);
            act.ShouldThrow<ArgumentException>();

            movies = new List<TraktMovie>
            {
                new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 }, Year = 12345 }
            };

            act = () => builder.AddMovies(movies);
            act.ShouldThrow<ArgumentException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddSeason()
        {
            var season1 = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 1,
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.ProgressWatched);

            builder.AddSeason(season1);

            var hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().BeNull();

            builder.AddSeason(season1);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().BeNull();

            season1.Ids.Trakt = 2;

            builder.AddSeason(season1);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().BeNull();

            var seasons = hiddenItemsPost.Seasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Ids.Should().NotBeNull();
            seasons[0].Ids.Trakt.Should().Be(2U);
            seasons[0].Ids.Tmdb.Should().Be(1234U);
            seasons[0].Ids.Tvdb.Should().Be(12345U);
            seasons[0].Ids.TvRage.Should().Be(123456U);

            var season2 = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3,
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddSeason(season2);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().BeNull();

            seasons = hiddenItemsPost.Seasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Ids.Should().NotBeNull();
            seasons[0].Ids.Trakt.Should().Be(2U);
            seasons[0].Ids.Tmdb.Should().Be(1234U);
            seasons[0].Ids.Tvdb.Should().Be(12345U);
            seasons[0].Ids.TvRage.Should().Be(123456U);

            seasons[1].Should().NotBeNull();
            seasons[1].Ids.Should().NotBeNull();
            seasons[1].Ids.Trakt.Should().Be(3U);
            seasons[1].Ids.Tmdb.Should().Be(12345U);
            seasons[1].Ids.Tvdb.Should().Be(123456U);
            seasons[1].Ids.TvRage.Should().Be(1234567U);
        }

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddSeasonArgumentExceptions()
        {
            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.ProgressWatched);

            Action act = () => builder.AddSeason(null);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddSeason(new TraktSeason());
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddSeason(new TraktSeason { Ids = new TraktSeasonIds() });
            act.ShouldThrow<ArgumentException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddSeasonsCollection()
        {
            var season1 = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 1,
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var season2 = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3,
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            var seasons = new List<TraktSeason>
            {
                season1,
                season2
            };

            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.ProgressWatched);

            builder.AddSeasons(seasons);

            var hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().BeNull();

            builder.AddSeasons(seasons);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().BeNull();

            season1.Ids.Trakt = 2;

            seasons = new List<TraktSeason>
            {
                season1,
                season2
            };

            builder.AddSeasons(seasons);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Movies.Should().BeNull();

            var historySeasons = hiddenItemsPost.Seasons.ToArray();

            historySeasons[0].Should().NotBeNull();
            historySeasons[0].Ids.Should().NotBeNull();
            historySeasons[0].Ids.Trakt.Should().Be(2U);
            historySeasons[0].Ids.Tmdb.Should().Be(1234U);
            historySeasons[0].Ids.Tvdb.Should().Be(12345U);
            historySeasons[0].Ids.TvRage.Should().Be(123456U);

            historySeasons[1].Should().NotBeNull();
            historySeasons[1].Ids.Should().NotBeNull();
            historySeasons[1].Ids.Trakt.Should().Be(3U);
            historySeasons[1].Ids.Tmdb.Should().Be(12345U);
            historySeasons[1].Ids.Tvdb.Should().Be(123456U);
            historySeasons[1].Ids.TvRage.Should().Be(1234567U);
        }

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddSeasonsCollectionArgumentExceptions()
        {
            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.ProgressWatched);

            Action act = () => builder.AddSeasons(null);
            act.ShouldThrow<ArgumentNullException>();

            var seasons = new List<TraktSeason>
            {
                new TraktSeason()
            };

            act = () => builder.AddSeasons(seasons);
            act.ShouldThrow<ArgumentNullException>();

            seasons = new List<TraktSeason>
            {
                new TraktSeason { Ids = new TraktSeasonIds() }
            };

            act = () => builder.AddSeasons(seasons);
            act.ShouldThrow<ArgumentException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddShow()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Recommendations);

            builder.AddShow(show1);

            var hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            builder.AddShow(show1);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            show1.Ids.Trakt = 2;

            builder.AddShow(show1);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            var shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().BeNull();

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShow(show2);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Movies.Should().BeNull();

            shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().BeNull();

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Seasons.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddShowArgumentExceptions()
        {
            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Recommendations);

            Action act = () => builder.AddShow(null);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow());
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds() });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 });
            act.ShouldThrow<ArgumentException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddShowsCollection()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            var shows = new List<TraktShow>
            {
                show1,
                show2
            };

            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Recommendations);

            builder.AddShows(shows);

            var hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Movies.Should().BeNull();

            builder.AddShows(shows);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Movies.Should().BeNull();

            show1.Ids.Trakt = 2;

            shows = new List<TraktShow>
            {
                show1,
                show2
            };

            builder.AddShows(shows);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Movies.Should().BeNull();

            var historyShows = hiddenItemsPost.Shows.ToArray();

            historyShows[0].Should().NotBeNull();
            historyShows[0].Title.Should().Be("show1");
            historyShows[0].Year.Should().Be(2016);
            historyShows[0].Ids.Should().NotBeNull();
            historyShows[0].Ids.Trakt.Should().Be(2U);
            historyShows[0].Ids.Slug.Should().Be("show1");
            historyShows[0].Ids.Imdb.Should().Be("imdb1");
            historyShows[0].Ids.Tmdb.Should().Be(1234U);
            historyShows[0].Ids.Tvdb.Should().Be(12345U);
            historyShows[0].Ids.TvRage.Should().Be(123456U);
            historyShows[0].Seasons.Should().BeNull();

            historyShows[1].Should().NotBeNull();
            historyShows[1].Title.Should().Be("show2");
            historyShows[1].Year.Should().Be(2016);
            historyShows[1].Ids.Should().NotBeNull();
            historyShows[1].Ids.Trakt.Should().Be(3U);
            historyShows[1].Ids.Slug.Should().Be("show2");
            historyShows[1].Ids.Imdb.Should().Be("imdb2");
            historyShows[1].Ids.Tmdb.Should().Be(12345U);
            historyShows[1].Ids.Tvdb.Should().Be(123456U);
            historyShows[1].Ids.TvRage.Should().Be(1234567U);
            historyShows[1].Seasons.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddShowsCollectionArgumentExceptions()
        {
            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Recommendations);

            Action act = () => builder.AddShows(null);
            act.ShouldThrow<ArgumentNullException>();

            var shows = new List<TraktShow>
            {
                new TraktShow()
            };

            act = () => builder.AddShows(shows);
            act.ShouldThrow<ArgumentNullException>();

            shows = new List<TraktShow>
            {
                new TraktShow { Ids = new TraktShowIds() }
            };

            act = () => builder.AddShows(shows);
            act.ShouldThrow<ArgumentException>();

            shows = new List<TraktShow>
            {
                new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }
            };

            act = () => builder.AddShows(shows);
            act.ShouldThrow<ArgumentException>();

            shows = new List<TraktShow>
            {
                new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }
            };

            act = () => builder.AddShows(shows);
            act.ShouldThrow<ArgumentException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddShowWithSeasons()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Recommendations);

            builder.AddShow(show1, 1);

            var hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            var shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);

            // ---------------------------------------------------------

            builder.AddShow(show1, 1, 2);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[1].Number.Should().Be(2);

            // ---------------------------------------------------------

            builder.AddShow(show1, 1, 2, 3);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[2].Number.Should().Be(3);

            // ---------------------------------------------------------

            show1.Ids.Trakt = 2;

            builder.AddShow(show1, 1, 2, 3);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[2].Number.Should().Be(3);

            // ---------------------------------------------------------

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShow(show2, 1, 2, 3);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Movies.Should().BeNull();

            shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[2].Number.Should().Be(3);

            var show2Seasons = shows[1].Seasons.ToArray();

            show2Seasons[0].Number.Should().Be(1);
            show2Seasons[1].Number.Should().Be(2);
            show2Seasons[2].Number.Should().Be(3);
        }

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddShowWithSeasonsArgumentExceptions()
        {
            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Recommendations);

            Action act = () => builder.AddShow(null, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow(), 1, 2, 3, 4);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds() }, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 1, 2, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddShowWithSeasonsArray()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var seasons = new int[] { 1 };

            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Recommendations);

            builder.AddShow(show1, seasons);

            var hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            var shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);

            // ---------------------------------------------------------

            seasons = new int[] { 1, 2 };

            builder.AddShow(show1, seasons);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[1].Number.Should().Be(2);

            // ---------------------------------------------------------

            seasons = new int[] { 1, 2, 3 };

            builder.AddShow(show1, seasons);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[2].Number.Should().Be(3);

            // ---------------------------------------------------------

            show1.Ids.Trakt = 2;

            seasons = new int[] { 1, 2, 3 };

            builder.AddShow(show1, seasons);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Movies.Should().BeNull();

            shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[2].Number.Should().Be(3);

            // ---------------------------------------------------------

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            seasons = new int[] { 1, 2, 3 };

            builder.AddShow(show2, seasons);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Movies.Should().BeNull();

            shows = hiddenItemsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[2].Number.Should().Be(3);

            var show2Seasons = shows[1].Seasons.ToArray();

            show2Seasons[0].Number.Should().Be(1);
            show2Seasons[1].Number.Should().Be(2);
            show2Seasons[2].Number.Should().Be(3);
        }

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddShowWithSeasonsArrayArgumentExceptions()
        {
            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Recommendations);

            var seasons = new int[] { 1, 2, 3, 4 };

            Action act = () => builder.AddShow(null, seasons);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow(), seasons);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds() }, seasons);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }, seasons);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }, seasons);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, default(int[]));
            act.ShouldThrow<ArgumentNullException>();

            seasons = new int[] { -1 };

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, seasons);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            seasons = new int[] { 1, 2, -1 };

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, seasons);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderReset()
        {
            var movie1 = new TraktMovie
            {
                Title = "movie1",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie1",
                    Imdb = "imdb1",
                    Tmdb = 1234
                }
            };

            var season1 = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 1,
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Recommendations);

            var hiddenItemsPost = builder.AddMovie(movie1)
                                    .AddSeason(season1)
                                    .AddShow(show1)
                                    .Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Seasons.Should().BeNull();

            builder.Reset(TraktHiddenItemsSection.Recommendations);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Movies.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Seasons.Should().BeNull();

            // --------------------

            builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.ProgressWatched);

            hiddenItemsPost = builder.AddMovie(movie1)
                                .AddSeason(season1)
                                .AddShow(show1)
                                .Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Movies.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            hiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            builder.Reset(TraktHiddenItemsSection.Recommendations);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Movies.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Seasons.Should().BeNull();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktUserHiddenItemsPostBuilderAddAll()
        {
            var movie1 = new TraktMovie
            {
                Title = "movie1",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie1",
                    Imdb = "imdb1",
                    Tmdb = 1234
                }
            };

            var movie2 = new TraktMovie
            {
                Title = "movie2",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 3,
                    Slug = "movie2",
                    Imdb = "imdb2",
                    Tmdb = 12345
                }
            };

            var season1 = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 1,
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var season2 = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 3,
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 2,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            var show3 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show3",
                    Imdb = "imdb3",
                    Tmdb = 123456,
                    Tvdb = 1234567,
                    TvRage = 12345678
                }
            };

            var show4 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 4,
                    Slug = "show4",
                    Imdb = "imdb4",
                    Tmdb = 1234567,
                    Tvdb = 12345678,
                    TvRage = 123456789
                }
            };

            var show5 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 5,
                    Slug = "show5",
                    Imdb = "imdb5",
                    Tmdb = 2234567,
                    Tvdb = 22345678,
                    TvRage = 223456789
                }
            };

            var show6 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 6,
                    Slug = "show6",
                    Imdb = "imdb6",
                    Tmdb = 2334567,
                    Tvdb = 23345678,
                    TvRage = 233456789
                }
            };

            var builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.Recommendations);

            var hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Movies.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Seasons.Should().BeNull();

            // ------------------------------------------------------

            hiddenItemsPost = builder.AddMovie(movie1)
                                .AddMovie(movie2)
                                .AddSeason(season1)
                                .AddSeason(season2)
                                .AddShow(show1)
                                .AddShow(show2)
                                .AddShow(show3, 1, 2, 3)
                                .AddShow(show4, 1, 2, 3)
                                .Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(4);
            hiddenItemsPost.Seasons.Should().BeNull();

            // -----------------------------------------------------
            // -----------------------------------------------------

            builder = TraktUserHiddenItemsPost.Builder(TraktHiddenItemsSection.ProgressWatched);

            hiddenItemsPost = builder.Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Movies.Should().BeNull();
            hiddenItemsPost.Shows.Should().BeNull();
            hiddenItemsPost.Seasons.Should().BeNull();

            // ------------------------------------------------------

            hiddenItemsPost = builder.AddMovie(movie1)
                                .AddMovie(movie2)
                                .AddSeason(season1)
                                .AddSeason(season2)
                                .AddShow(show1)
                                .AddShow(show2)
                                .AddShow(show3, 1, 2, 3)
                                .AddShow(show4, 1, 2, 3)
                                .Build();

            hiddenItemsPost.Should().NotBeNull();
            hiddenItemsPost.Movies.Should().BeNull();
            hiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(4);
            hiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(2);
        }
    }
}

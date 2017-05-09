namespace TraktApiSharp.Objects.Post.Users.HiddenItems
{
    using Enums;
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A Trakt hidden items post, containing all movies, shows and / or seasons,
    /// which should be added to the user's hidden items.
    /// </summary>
    public class TraktUsersHiddenItemsPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktUsersHiddenItemsPostMovie" />s.
        /// <para>Each <see cref="TraktUsersHiddenItemsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktUsersHiddenItemsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUsersHiddenItemsPostShow" />s.
        /// <para>Each <see cref="TraktUsersHiddenItemsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktUsersHiddenItemsPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUsersHiddenItemsPostSeason" />s.
        /// <para>Each <see cref="TraktUsersHiddenItemsPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktUsersHiddenItemsPostSeason> Seasons { get; set; }

        /// <summary>Returns a new <see cref="TraktUsersHiddenItemsPostBuilder" /> instance.</summary>
        /// <param name="section">The section of hidden items, where the added objects should be hidden or unhidden. See also <see cref="TraktHiddenItemsSection "/>.</param>
        /// <returns>A new <see cref="TraktUsersHiddenItemsPostBuilder" /> instance.</returns>
        public static TraktUsersHiddenItemsPostBuilder Builder(TraktHiddenItemsSection section) => new TraktUsersHiddenItemsPostBuilder(section);
    }

    /// <summary>
    /// This is a helper class to build a <see cref="TraktUsersHiddenItemsPost" />.
    /// <para>
    /// It is recommended to use this class to build a hidden items post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktUsersHiddenItemsPost.Builder(TraktHiddenItemsSection)" />.
    /// </para>
    /// </summary>
    public class TraktUsersHiddenItemsPostBuilder
    {
        private TraktHiddenItemsSection _section;
        private IEnumerable<TraktUsersHiddenItemsPostMovie> _movies;
        private IEnumerable<TraktUsersHiddenItemsPostShow> _shows;
        private IEnumerable<TraktUsersHiddenItemsPostSeason> _seasons;

        /// <summary>Initializes a new instance of the <see cref="TraktUsersHiddenItemsPost" /> class.</summary>
        /// <param name="section">The section of hidden items, where the added objects should be hidden or unhidden. See also <see cref="TraktHiddenItemsSection "/>.</param>
        /// <exception cref="ArgumentNullException">Thrown, if the given section is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given section is unspecified.</exception>
        public TraktUsersHiddenItemsPostBuilder(TraktHiddenItemsSection section)
        {
            SetSection(section);
            _movies = new List<TraktUsersHiddenItemsPostMovie>();
            _shows = new List<TraktUsersHiddenItemsPostShow>();
            _seasons = new List<TraktUsersHiddenItemsPostSeason>();
        }

        internal TraktHiddenItemsSection Section => _section;

        /// <summary>Adds a <see cref="TraktMovie" />, which will be added to the hidden items post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <returns>The current <see cref="TraktUsersHiddenItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktUsersHiddenItemsPostBuilder AddMovie(TraktMovie movie)
        {
            if (!IsSectionValidForMovies)
                return this;

            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie);
        }

        /// <summary>Adds a collection of <see cref="TraktMovie" />s, which will be added to the hidden items post.</summary>
        /// <param name="movies">A collection of Trakt movies, which will be added.</param>
        /// <returns>The current <see cref="TraktUsersHiddenItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movies collection is null.
        /// Thrown, if one of the given movies is null.
        /// Thrown, if one of the given movies' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given movies has no valid ids set.
        /// Thrown, if one of the given movies has an year set, which has more or less than four digits.
        /// </exception>
        public TraktUsersHiddenItemsPostBuilder AddMovies(IEnumerable<TraktMovie> movies)
        {
            if (!IsSectionValidForMovies)
                return this;

            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            if (movies.Count() == 0)
                return this;

            foreach (var movie in movies)
                AddMovie(movie);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the hidden items post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <returns>The current <see cref="TraktUsersHiddenItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktUsersHiddenItemsPostBuilder AddShow(TraktShow show)
        {
            if (!IsSectionValidForShows)
                return this;

            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show);
        }

        /// <summary>Adds a collection of <see cref="TraktShow" />s, which will be added to the hidden items post.</summary>
        /// <param name="shows">A collection of Trakt shows, which will be added.</param>
        /// <returns>The current <see cref="TraktUsersHiddenItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given shows collection is null.
        /// Thrown, if one of the given shows is null.
        /// Thrown, if one of the given shows' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given shows has no valid ids set.
        /// Thrown, if one of the given shows has an year set, which has more or less than four digits.
        /// </exception>
        public TraktUsersHiddenItemsPostBuilder AddShows(IEnumerable<TraktShow> shows)
        {
            if (!IsSectionValidForShows)
                return this;

            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            if (shows.Count() == 0)
                return this;

            foreach (var show in shows)
                AddShow(show);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the hidden items post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the hidden items.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the hidden items.
        /// </param>
        /// <returns>The current <see cref="TraktUsersHiddenItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// </exception>
        public TraktUsersHiddenItemsPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            if (!IsSectionValidForShows)
                return this;

            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktShow" />, which will be added to the hidden items post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the hidden items.
        /// </param>
        /// <returns>The current <see cref="TraktUsersHiddenItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// Thrown, if the given seasons array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// </exception>
        public TraktUsersHiddenItemsPostBuilder AddShow(TraktShow show, int[] seasons)
        {
            if (!IsSectionValidForShows)
                return this;

            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        /// <summary>Adds a <see cref="TraktSeason" />, which will be added to the hidden items post.</summary>
        /// <param name="season">The Trakt season, which will be added.</param>
        /// <returns>The current <see cref="TraktUsersHiddenItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given season is null.
        /// Thrown, if the given season ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if the given season has no valid ids set.</exception>
        public TraktUsersHiddenItemsPostBuilder AddSeason(TraktSeason season)
        {
            if (!IsSectionValidForSeasons)
                return this;

            ValidateSeason(season);
            EnsureSeasonsListExists();

            return AddSeasonOrIgnore(season);
        }

        /// <summary>Adds a collection of <see cref="TraktSeason" />s, which will be added to the hidden items post.</summary>
        /// <param name="seasons">A collection of Trakt seasons, which will be added.</param>
        /// <returns>The current <see cref="TraktUsersHiddenItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given episodes collection is null.
        /// Thrown, if one of the given seasons is null.
        /// Thrown, if one of the given seasons' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given seasons has no valid ids set.</exception>
        public TraktUsersHiddenItemsPostBuilder AddSeasons(IEnumerable<TraktSeason> seasons)
        {
            if (!IsSectionValidForSeasons)
                return this;

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            if (seasons.Count() == 0)
                return this;

            foreach (var episode in seasons)
                AddSeason(episode);

            return this;
        }

        /// <summary>Removes all already added movies, shows and seasons from the builder.</summary>
        /// <param name="section">The section of hidden items, where the added objects should be hidden or unhidden. See also <see cref="TraktHiddenItemsSection "/>.</param>
        /// <exception cref="ArgumentNullException">Thrown, if the given section is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given section is unspecified.</exception>
        public TraktUsersHiddenItemsPostBuilder Reset(TraktHiddenItemsSection section)
        {
            SetSection(section);
            _movies = new List<TraktUsersHiddenItemsPostMovie>();
            _shows = new List<TraktUsersHiddenItemsPostShow>();
            _seasons = new List<TraktUsersHiddenItemsPostSeason>();

            return this;
        }

        /// <summary>
        /// Returns an <see cref="TraktUsersHiddenItemsPost" /> instance, which contains all
        /// added movies, shows and seasons.
        /// </summary>
        /// <returns>An <see cref="TraktUsersHiddenItemsPost" /> instance.</returns>
        public TraktUsersHiddenItemsPost Build()
        {
            return new TraktUsersHiddenItemsPost
            {
                Movies = _movies.Count() > 0 ? _movies : null,
                Shows = _shows.Count() > 0 ? _shows : null,
                Seasons = _seasons.Count() > 0 ? _seasons : null
            };
        }

        private void SetSection(TraktHiddenItemsSection section)
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            if (section == TraktHiddenItemsSection.Unspecified)
                throw new ArgumentException("section must not be unspecifed", nameof(section));

            _section = section;
        }

        private bool IsSectionValidForMovies
            => _section == TraktHiddenItemsSection.Calendar || _section == TraktHiddenItemsSection.Recommendations;

        private bool IsSectionValidForShows
            => _section == TraktHiddenItemsSection.Calendar || _section == TraktHiddenItemsSection.ProgressWatched
                || _section == TraktHiddenItemsSection.ProgressCollected || _section == TraktHiddenItemsSection.Recommendations;

        private bool IsSectionValidForSeasons
            => _section == TraktHiddenItemsSection.ProgressWatched || _section == TraktHiddenItemsSection.ProgressCollected;

        private void ValidateMovie(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));

            if (movie.Year.HasValue && movie.Year.Value.ToString().Length != 4)
                throw new ArgumentException("movie year not valid", nameof(movie.Year));
        }

        private void ValidateShow(TraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (show.Ids == null)
                throw new ArgumentNullException(nameof(show.Ids));

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("no show ids set or valid", nameof(show.Ids));

            if (show.Year.HasValue && show.Year.Value.ToString().Length != 4)
                throw new ArgumentException("show year not valid", nameof(show.Year));
        }

        private void ValidateSeason(TraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            if (season.Ids == null)
                throw new ArgumentNullException(nameof(season.Ids));

            if (!season.Ids.HasAnyId)
                throw new ArgumentException("no season ids set or valid", nameof(season.Ids));
        }

        private bool ContainsMovie(TraktMovie movie) => _movies.Where(m => m.Ids == movie.Ids).FirstOrDefault() != null;

        private void EnsureMoviesListExists()
        {
            if (_movies == null)
                _movies = new List<TraktUsersHiddenItemsPostMovie>();
        }

        private bool ContainsShow(TraktShow show) => _shows.Where(s => s.Ids == show.Ids).FirstOrDefault() != null;

        private void EnsureShowsListExists()
        {
            if (_shows == null)
                _shows = new List<TraktUsersHiddenItemsPostShow>();
        }

        private bool ContainsSeason(TraktSeason season) => _seasons.Where(s => s.Ids == season.Ids).FirstOrDefault() != null;

        private void EnsureSeasonsListExists()
        {
            if (_seasons == null)
                _seasons = new List<TraktUsersHiddenItemsPostSeason>();
        }

        private TraktUsersHiddenItemsPostBuilder AddMovieOrIgnore(TraktMovie movie)
        {
            if (ContainsMovie(movie))
                return this;

            var hiddenItemMovie = new TraktUsersHiddenItemsPostMovie()
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            (_movies as List<TraktUsersHiddenItemsPostMovie>).Add(hiddenItemMovie);

            return this;
        }

        private TraktUsersHiddenItemsPostBuilder AddShowOrIgnore(TraktShow show)
        {
            if (ContainsShow(show))
                return this;

            var hiddenItemShow = new TraktUsersHiddenItemsPostShow()
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            (_shows as List<TraktUsersHiddenItemsPostShow>).Add(hiddenItemShow);

            return this;
        }

        private TraktUsersHiddenItemsPostBuilder AddSeasonOrIgnore(TraktSeason season)
        {
            if (ContainsSeason(season))
                return this;

            var hiddenItemSeason = new TraktUsersHiddenItemsPostSeason()
            {
                Ids = season.Ids
            };

            (_seasons as List<TraktUsersHiddenItemsPostSeason>).Add(hiddenItemSeason);

            return this;
        }

        private void CreateOrSetShow(TraktShow show, IEnumerable<TraktUsersHiddenItemsPostShowSeason> showSeasons,
                                       DateTime? watchedAt = null)
        {
            var existingShow = _shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var hiddenItemsShow = new TraktUsersHiddenItemsPostShow()
                {
                    Ids = show.Ids,
                    Title = show.Title,
                    Year = show.Year,
                    Seasons = showSeasons
                };

                (_shows as List<TraktUsersHiddenItemsPostShow>).Add(hiddenItemsShow);
            }
        }

        private IEnumerable<TraktUsersHiddenItemsPostShowSeason> CreateShowSeasons(int season, params int[] seasons)
        {
            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<TraktUsersHiddenItemsPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktUsersHiddenItemsPostShowSeason { Number = seasonsToAdd[i] });
            }

            return showSeasons;
        }

        private IEnumerable<TraktUsersHiddenItemsPostShowSeason> CreateShowSeasons(int[] seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            var showSeasons = new List<TraktUsersHiddenItemsPostShowSeason>();

            for (int i = 0; i < seasons.Length; i++)
            {
                if (seasons[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktUsersHiddenItemsPostShowSeason { Number = seasons[i] });
            }

            return showSeasons;
        }
    }
}

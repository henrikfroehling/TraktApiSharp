﻿namespace TraktApiSharp.Modules
{
    using Exceptions;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Episodes.Implementations;
    using Objects.Get.Movies;
    using Objects.Get.Movies.Implementations;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Implementations;
    using Objects.Post.Checkins.Implementations;
    using Objects.Post.Checkins.Responses;
    using Requests.Checkins.OAuth;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktApiSharp.Objects.Post.Checkins;

    /// <summary>
    /// Provides access to data retrieving methods specific to checkins.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/checkin">"Trakt API Doc - Checkin"</a> section.
    /// </para>
    /// </summary>
    public class TraktCheckinsModule : ATraktModule
    {
        internal TraktCheckinsModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Checks into the given <see cref="ITraktMovie" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="ITraktMovie" />, which will be checked in.</param>
        /// <param name="appVersion">Optional application version for the checkin.</param>
        /// <param name="appBuildDate">Optional application build date for the checkin. Will be converted to the Trakt date-format.</param>
        /// <param name="message">The message, which will be used for sharing. If none is given, the user's default message will be used.</param>
        /// <param name="sharing">Optional sharing settings, which will override the user's default sharing settings.</param>
        /// <param name="foursquareVenueID">Optional Foursquare venue id for the checkin.</param>
        /// <param name="foursquareVenueName">Optional Foursquare venue name for the checkin.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktMovieCheckinPostResponse" /> instance, containing the successfully checked in movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie's title is null or empty.
        /// Thrown, if the given movie has no valid ids set.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or if its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given movie's year is not valid.</exception>
        public Task<TraktResponse<ITraktMovieCheckinPostResponse>> CheckIntoMovieAsync(ITraktMovie movie, string appVersion = null, DateTime? appBuildDate = null,
                                                                                       string message = null, ITraktSharing sharing = null,
                                                                                       string foursquareVenueID = null, string foursquareVenueName = null,
                                                                                       CancellationToken cancellationToken = default)
        {
            Validate(movie);

            var requestBody = new TraktMovieCheckinPost
            {
                Movie = new TraktMovie
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Ids = movie.Ids
                },
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CheckinRequest<ITraktMovieCheckinPostResponse, ITraktMovieCheckinPost>
            {
                RequestBody = requestBody
            }, cancellationToken);
        }

        /// <summary>
        /// Checks into the given <see cref="ITraktEpisode" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, which will be checked in.</param>
        /// <param name="appVersion">Optional application version for the checkin.</param>
        /// <param name="appBuildDate">Optional application build date for the checkin. Will be converted to the Trakt date-format.</param>
        /// <param name="message">The message, which will be used for sharing. If none is given, the user's default message will be used.</param>
        /// <param name="sharing">Optional sharing settings, which will override the user's default sharing settings.</param>
        /// <param name="foursquareVenueID">Optional Foursquare venue id for the checkin.</param>
        /// <param name="foursquareVenueName">Optional Foursquare venue name for the checkin.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktEpisodeCheckinPostResponse" /> instance, containing the successfully checked in episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if its ids are null.</exception>
        public Task<TraktResponse<ITraktEpisodeCheckinPostResponse>> CheckIntoEpisodeAsync(ITraktEpisode episode, string appVersion = null, DateTime? appBuildDate = null,
                                                                                           string message = null, ITraktSharing sharing = null,
                                                                                           string foursquareVenueID = null, string foursquareVenueName = null,
                                                                                           CancellationToken cancellationToken = default)
        {
            Validate(episode);

            var requestBody = new TraktEpisodeCheckinPost
            {
                Episode = new TraktEpisode
                {
                    Ids = episode.Ids,
                    SeasonNumber = episode.SeasonNumber,
                    Number = episode.Number
                },
                Show = null,
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CheckinRequest<ITraktEpisodeCheckinPostResponse, ITraktEpisodeCheckinPost>
            {
                RequestBody = requestBody
            }, cancellationToken);
        }

        /// <summary>
        /// Checks into the given <see cref="ITraktEpisode" />. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, which will be checked in.</param>
        /// <param name="show">The <see cref="ITraktShow" />, which will be used to check into the given episode.</param>
        /// <param name="appVersion">Optional application version for the checkin.</param>
        /// <param name="appBuildDate">Optional application build date for the checkin. Will be converted to the Trakt date-format.</param>
        /// <param name="message">The message, which will be used for sharing. If none is given, the user's default message will be used.</param>
        /// <param name="sharing">Optional sharing settings, which will override the user's default sharing settings.</param>
        /// <param name="foursquareVenueID">Optional Foursquare venue id for the checkin.</param>
        /// <param name="foursquareVenueName">Optional Foursquare venue name for the checkin.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktEpisodeCheckinPostResponse" /> instance, containing the successfully checked in episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given show's title is null or empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null. Thrown, if the given show is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given episode's season number or the given episode's number is below zero.</exception>
        public Task<TraktResponse<ITraktEpisodeCheckinPostResponse>> CheckIntoEpisodeWithShowAsync(ITraktEpisode episode, ITraktShow show,
                                                                                                   string appVersion = null, DateTime? appBuildDate = null,
                                                                                                   string message = null, ITraktSharing sharing = null,
                                                                                                   string foursquareVenueID = null, string foursquareVenueName = null,
                                                                                                   CancellationToken cancellationToken = default)
        {
            Validate(episode, show);

            var requestBody = new TraktEpisodeCheckinPost
            {
                Episode = new TraktEpisode
                {
                    Ids = episode.Ids,
                    SeasonNumber = episode.SeasonNumber,
                    Number = episode.Number
                },
                Show = new TraktShow { Title = show.Title },
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CheckinRequest<ITraktEpisodeCheckinPostResponse, ITraktEpisodeCheckinPost>
            {
                RequestBody = requestBody
            }, cancellationToken);
        }

        /// <summary>
        /// Deletes any active checkins.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/checkin/delete-any-active-checkins">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktNoContentResponse> DeleteAnyActiveCheckinsAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteNoContentRequestAsync(new CheckinsDeleteRequest(), cancellationToken);
        }

        private void Validate(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "movie must not be null");

            if (string.IsNullOrEmpty(movie.Title))
                throw new ArgumentException("movie title not valid", nameof(movie.Title));

            if (movie.Year <= 0 || movie.Year.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(movie), "movie year not valid");

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids), "movie.Ids must not be null");

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie.Ids have no valid id", nameof(movie.Ids));
        }

        private void Validate(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode), "episode must not be null");

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids), "episode.Ids must not be null");

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode.Ids have no valid id", nameof(episode.Ids));
        }

        private void Validate(ITraktEpisode episode, ITraktShow show)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode), "episode must not be null");

            if (episode.SeasonNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(episode.SeasonNumber), "episode season number not valid");

            if (episode.Number < 0)
                throw new ArgumentOutOfRangeException(nameof(episode.Number), "episode number not valid");

            if (show == null)
                throw new ArgumentNullException(nameof(show), "show must not be null");

            if (string.IsNullOrEmpty(show.Title))
                throw new ArgumentException("show title not valid", nameof(show.Title));
        }
    }
}

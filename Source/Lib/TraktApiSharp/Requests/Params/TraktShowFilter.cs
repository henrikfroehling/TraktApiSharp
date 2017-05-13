﻿namespace TraktApiSharp.Requests.Params
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using Utils;

    /// <summary>
    /// Provides additional filter parameters for some <see cref="Modules.TraktShowsModule" /> methods.<para />
    /// Supported by <see cref="Modules.TraktShowsModule.GetMostAnticipatedShowsAsync(TraktExtendedInfo, TraktShowFilter, int?, int?)" />,
    /// <see cref="Modules.TraktShowsModule.GetMostCollectedShowsAsync(TraktTimePeriod, TraktExtendedInfo, TraktShowFilter, int?, int?)" />,
    /// <see cref="Modules.TraktShowsModule.GetMostPlayedShowsAsync(TraktTimePeriod, TraktExtendedInfo, TraktShowFilter, int?, int?)" />,
    /// <see cref="Modules.TraktShowsModule.GetMostWatchedShowsAsync(TraktTimePeriod, TraktExtendedInfo, TraktShowFilter, int?, int?)" />,
    /// <see cref="Modules.TraktShowsModule.GetPopularShowsAsync(TraktExtendedInfo, TraktShowFilter, int?, int?)" />,
    /// <see cref="Modules.TraktShowsModule.GetRecentlyUpdatedShowsAsync(DateTime?, TraktExtendedInfo, int?, int?)" /> and
    /// <see cref="Modules.TraktShowsModule.GetTrendingShowsAsync(TraktExtendedInfo, TraktShowFilter, int?, int?)" />.<para />
    /// This class has an fluent interface.
    /// <para>See <a href ="http://docs.trakt.apiary.io/#introduction/filters">"Trakt API Doc - Filters"</a> for more information.</para>
    /// </summary>
    public class TraktShowFilter : TraktCommonMovieAndShowFilter
    {
        /// <summary>Initializes an <see cref="TraktShowFilter" /> instance with the given values.</summary>
        /// <param name="query">An optional query string for titles and descriptions.</param>
        /// <param name="startYear">An optional four digit start year for the years parameter.</param>
        /// <param name="endYear">An optional four digit end year for the years parameter.</param>
        /// <param name="genres">An optional array of Trakt genre slugs.</param>
        /// <param name="languages">An optional array of two letter language codes.</param>
        /// <param name="countries">An optional array of two letter country codes.</param>
        /// <param name="runtimes">An optional <see cref="Range{T}" /> instance for minutes.</param>
        /// <param name="ratings">An optional <see cref="Range{T}" /> instance for ratings.</param>
        /// <param name="certifications">An optional array of content certificiations.</param>
        /// <param name="networks">An optional aarray of network names.</param>
        /// <param name="states">An optional aarray of show states. See also <seealso cref="TraktShowStatus" />.</param>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given query string is null or empty.
        /// Thrown, if one of the given states is unspecified.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given <paramref name="startYear" /> value does not have four digits.
        /// Thrown, if the given <paramref name="endYear" /> value does not have four digits.
        /// Thrown, if the begin value of the given runtimes range is below zero or if its end value is below zero or
        /// if its end value is below its begin value.
        /// Thrown, if the begin value of the given ratings range is below zero or if its end value is below zero or
        /// if its end value is below its begin value or if its end value is above 100.
        /// Thrown, if the given language codes array contains a language code, which has more or less than two letters.
        /// Thrown, if the given country codes array contains a country code, which has more or less than two letters.
        /// </exception>
        public TraktShowFilter(string query = null, int? startYear = null, int? endYear = null, string[] genres = null,
                               string[] languages = null, string[] countries = null, Range<int>? runtimes = null,
                               Range<int>? ratings = null, string[] certifications = null, string[] networks = null,
                               TraktShowStatus[] states = null)
            : base(query, startYear, endYear, genres, languages, countries, runtimes, ratings, certifications)
        {
            WithNetworks(null, networks);
            WithStates(TraktShowStatus.Unspecified, states);
        }

        /// <summary>Returns the network names parameter value.</summary>
        public string[] Networks { get; private set; }

        /// <summary>Returns, whether the network names parameter is set.</summary>
        public bool HasNetworksSet => Networks != null && Networks.Length > 0;

        /// <summary>Returns the show states parameter value.</summary>
        public TraktShowStatus[] States { get; private set; }

        /// <summary>Returns, whether the show states parameter is set.</summary>
        public bool HasStatesSet => States != null && States.Length > 0;

        /// <summary>Returns, whether any parameters are set.</summary>
        public override bool HasValues => base.HasValues || HasNetworksSet || HasStatesSet;

        /// <summary>Sets the query string parameter value.</summary>
        /// <param name="query">The query string for titles and descriptions.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentException">Thrown, if the given query string is null or empty.</exception>
        public new TraktShowFilter WithQuery(string query)
        {
            base.WithQuery(query);
            return this;
        }

        /// <summary>Deletes the current query value.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter ClearQuery()
        {
            base.ClearQuery();
            return this;
        }

        /// <summary>Sets the start year for the years parameter value.</summary>
        /// <param name="startYear">A four digit year.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given year does not have four digits.</exception>
        public new TraktShowFilter WithStartYear(int startYear)
        {
            base.WithStartYear(startYear);
            return this;
        }

        /// <summary>Sets the end year for the years parameter value.</summary>
        /// <param name="endYear">A four digit year.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given year does not have four digits.</exception>
        public new TraktShowFilter WithEndYear(int endYear)
        {
            base.WithEndYear(endYear);
            return this;
        }

        /// <summary>Sets the start and end year for the years parameter value.</summary>
        /// <param name="startYear">A four digit year.</param>
        /// <param name="endYear">A four digit year.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if at least on of the given year values does not have four digits.</exception>
        public new TraktShowFilter WithYears(int startYear, int endYear)
        {
            base.WithYears(startYear, endYear);
            return this;
        }

        /// <summary>Deletes the current start year of the years parameter.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter ClearStartYear()
        {
            base.ClearStartYear();
            return this;
        }

        /// <summary>Deletes the current end year of the years parameter.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter ClearEndYear()
        {
            base.ClearEndYear();
            return this;
        }

        /// <summary>Deletes the current years parameter.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter ClearYears()
        {
            base.ClearYears();
            return this;
        }

        /// <summary>Adds multiple Trakt genre slugs to the already existing Trakt genre slugs.</summary>
        /// <param name="genre">A Trakt genre slug.</param>
        /// <param name="genres">An optional array of Trakt genre slugs.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter AddGenres(string genre, params string[] genres)
        {
            base.AddGenres(genre, genres);
            return this;
        }

        /// <summary>Sets the Trakt genre slugs parameter and overwrites already existing ones with given Trakt genre slugs.</summary>
        /// <param name="genre">A Trakt genre slug.</param>
        /// <param name="genres">An optional array of Trakt genre slugs.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter WithGenres(string genre, params string[] genres)
        {
            base.WithGenres(genre, genres);
            return this;
        }

        /// <summary>Deletes the current genre values.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter ClearGenres()
        {
            base.ClearGenres();
            return this;
        }

        /// <summary>Adds multiple language codes to the already existing language codes.</summary>
        /// <param name="language">A two letter language code.</param>
        /// <param name="languages">An optional array of two letter language codes.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one the given language codes has more or less than two letters.
        /// </exception>
        public new TraktShowFilter AddLanguages(string language, params string[] languages)
        {
            base.AddLanguages(language, languages);
            return this;
        }

        /// <summary>Sets the language codes parameter and overwrites already existing ones with given language codes.</summary>
        /// <param name="language">A two letter language code.</param>
        /// <param name="languages">An optional array of two letter language codes.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one the given language codes has more or less than two letters.
        /// </exception>
        public new TraktShowFilter WithLanguages(string language, params string[] languages)
        {
            base.WithLanguages(language, languages);
            return this;
        }

        /// <summary>Deletes the current language values.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter ClearLanguages()
        {
            base.ClearLanguages();
            return this;
        }

        /// <summary>Adds multiple country codes to the already existing country codes.</summary>
        /// <param name="country">A two letter country code.</param>
        /// <param name="countries">An optional array of two letter country codes.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one the given country codes has more or less than two letters.
        /// </exception>
        public new TraktShowFilter AddCountries(string country, params string[] countries)
        {
            base.AddCountries(country, countries);
            return this;
        }

        /// <summary>Sets the country codes parameter and overwrites already existing ones with given country codes.</summary>
        /// <param name="country">A two letter country code.</param>
        /// <param name="countries">An optional array of two letter country codes.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one the given country codes has more or less than two letters.
        /// </exception>
        public new TraktShowFilter WithCountries(string country, params string[] countries)
        {
            base.WithCountries(country, countries);
            return this;
        }

        /// <summary>Deletes the current country values.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter ClearCountries()
        {
            base.ClearCountries();
            return this;
        }

        /// <summary>Sets the runtimes value parameter and overwrites already exisiting values with the given ones.</summary>
        /// <param name="begin">The begin value of the runtimes range.</param>
        /// <param name="end">The end value of the runtimes range.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given begin value is below zero or if the given end value is below zero or
        /// if the given end value is below the given begin value.
        /// </exception>
        public new TraktShowFilter WithRuntimes(int begin, int end)
        {
            base.WithRuntimes(begin, end);
            return this;
        }

        /// <summary>Deletes the current runtime values.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter ClearRuntimes()
        {
            base.ClearRuntimes();
            return this;
        }

        /// <summary>Sets the ratings value parameter and overwrites already exisiting values with the given ones.</summary>
        /// <param name="begin">The begin value of ratings range.</param>
        /// <param name="end">The end value of the ratings range.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given begin value is below zero or if the given end value is below zero or
        /// if the given end value is below the given begin value or if the given end value is above 100.
        /// </exception>
        public new TraktShowFilter WithRatings(int begin, int end)
        {
            base.WithRatings(begin, end);
            return this;
        }

        /// <summary>Deletes the current rating values.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter ClearRatings()
        {
            base.ClearRatings();
            return this;
        }

        /// <summary>Adds multiple content certifications to the already existing content certifications.</summary>
        /// <param name="certification">A content certification.</param>
        /// <param name="certifications">An optional array of content certifications.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter AddCertifications(string certification, params string[] certifications)
        {
            base.AddCertifications(certification, certifications);
            return this;
        }

        /// <summary>Sets the content certifications parameter and overwrites already existing ones with given content certifications.</summary>
        /// <param name="certification">A content certification.</param>
        /// <param name="certifications">An optional array of content certifications.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter WithCertifications(string certification, params string[] certifications)
        {
            base.WithCertifications(certification, certifications);
            return this;
        }

        /// <summary>Deletes the current certification values.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public new TraktShowFilter ClearCertifications()
        {
            base.ClearCertifications();
            return this;
        }

        /// <summary>Adds multiple network names to the already existing network names.</summary>
        /// <param name="network">A network name.</param>
        /// <param name="networks">An optional array of network names.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public TraktShowFilter AddNetworks(string network, params string[] networks) => AddNetworks(true, network, networks);

        /// <summary>Sets the network names parameter and overwrites already existing ones with given network names.</summary>
        /// <param name="network">A network name.</param>
        /// <param name="networks">An optional array of network names.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public TraktShowFilter WithNetworks(string network, params string[] networks) => AddNetworks(false, network, networks);

        /// <summary>Deletes the current network values.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public TraktShowFilter ClearNetworks()
        {
            Networks = null;
            return this;
        }

        /// <summary>Adds multiple show states to the already existing show states.</summary>
        /// <param name="status">A show status. See also <seealso cref="TraktShowStatus" />.</param>
        /// <param name="states">An optional array of show states. See also <seealso cref="TraktShowStatus" />.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentException">Thrown, if one the given show states is unspecified.</exception>
        public TraktShowFilter AddStates(TraktShowStatus status, params TraktShowStatus[] states) => AddStates(true, status, states);

        /// <summary>Sets the show states parameter and overwrites already existing ones with given show states.</summary>
        /// <param name="status">A show status. See also <seealso cref="TraktShowStatus" />.</param>
        /// <param name="states">An optional array of show states. See also <seealso cref="TraktShowStatus" />.</param>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        /// <exception cref="ArgumentException">Thrown, if one the given show states is unspecified.</exception>
        public TraktShowFilter WithStates(TraktShowStatus status, params TraktShowStatus[] states) => AddStates(false, status, states);

        /// <summary>Deletes the current state values.</summary>
        /// <returns>The current <see cref="TraktShowFilter" /> instance.</returns>
        public TraktShowFilter ClearStates()
        {
            States = null;
            return this;
        }

        /// <summary>Deletes all filter parameter values.</summary>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        public new TraktShowFilter Clear()
        {
            base.Clear();
            Networks = null;
            States = null;
            return this;
        }

        /// <summary>
        /// Creates a key-value-pair list of all set parameter-values.
        /// Each key-value-pair consists of the parameter name as key and its value.
        /// </summary>
        /// <returns>A key-value-pair list of all set parameter-values.</returns>
        public override IDictionary<string, object> GetParameters()
        {
            var parameters = base.GetParameters();

            if (HasNetworksSet)
                parameters.Add("networks", string.Join(",", Networks));

            if (HasStatesSet)
            {
                var statesAsString = new string[States.Length];

                for (int i = 0; i < States.Length; i++)
                    statesAsString[i] = States[i].UriName;

                parameters.Add("status", string.Join(",", statesAsString));
            }

            return parameters;
        }

        private TraktShowFilter AddNetworks(bool keepExisting, string network, params string[] networks)
        {
            if (string.IsNullOrEmpty(network) && (networks == null || networks.Length <= 0))
            {
                if (!keepExisting)
                    Networks = null;

                return this;
            }

            var networksList = new List<string>();

            if (keepExisting && Networks != null && Networks.Length > 0)
                networksList.AddRange(Networks);

            if (!string.IsNullOrEmpty(network))
                networksList.Add(network);

            if (networks != null && networks.Length > 0)
                networksList.AddRange(networks);

            Networks = networksList.ToArray();

            return this;
        }

        private TraktShowFilter AddStates(bool keepExisting, TraktShowStatus status, params TraktShowStatus[] states)
        {
            if ((status == null || status == TraktShowStatus.Unspecified) && (states == null || states.Length <= 0))
            {
                if (!keepExisting)
                    States = null;

                return this;
            }

            var statesList = new List<TraktShowStatus>();

            if (keepExisting && States != null && States.Length > 0)
                statesList.AddRange(States);

            if (status != null && status != TraktShowStatus.Unspecified)
                statesList.Add(status);

            if (states != null && states.Length > 0)
            {
                for (int i = 0; i < states.Length; i++)
                {
                    if (states[i] == null || states[i] == TraktShowStatus.Unspecified)
                        throw new ArgumentException("status not valid", nameof(states));
                }

                statesList.AddRange(states);
            }

            States = statesList.ToArray();

            return this;
        }
    }
}

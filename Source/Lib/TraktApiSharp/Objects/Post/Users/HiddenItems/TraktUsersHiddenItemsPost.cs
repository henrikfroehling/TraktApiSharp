namespace TraktApiSharp.Objects.Post.Users.HiddenItems
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

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
    }
}

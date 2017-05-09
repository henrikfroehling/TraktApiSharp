namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the response for a hidden items post. See also <see cref="TraktUserHiddenItemsPost" />.
    /// <para>Contains the number of added and not found movies, shows and seasons.</para>
    /// </summary>
    public class TraktUserHiddenItemsPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows and seasons.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "added")]
        [Nullable]
        public TraktUserHiddenItemsPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows and seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktUserHiddenItemsPostResponseNotFound NotFound { get; set; }
    }
}

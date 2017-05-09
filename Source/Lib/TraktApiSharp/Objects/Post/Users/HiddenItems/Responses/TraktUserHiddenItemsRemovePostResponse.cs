namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the response for a hidden items remove post. See also <see cref="TraktUserHiddenItemsPost" />.
    /// <para>Contains the number of deleted and not found movies, shows and seasons.</para>
    /// </summary>
    public class TraktUserHiddenItemsRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies, shows and seasons.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "deleted")]
        [Nullable]
        public TraktUserHiddenItemsPostResponseGroup Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows and seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktUserHiddenItemsPostResponseNotFound NotFound { get; set; }
    }
}

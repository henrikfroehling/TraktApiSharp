namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses
{
    using Attributes;
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of hidden movies, shows and seasons, which were not found.</summary>
    public class TraktUserHiddenItemsPostResponseNotFound
    {
        /// <summary>
        /// A list of <see cref="TraktUserHiddenItemsPostResponseNotFoundItem{T}" />, containing the ids of hidden movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        [Nullable]
        public IEnumerable<TraktUserHiddenItemsPostResponseNotFoundItem<TraktMovieIds>> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="TraktUserHiddenItemsPostResponseNotFoundItem{T}" />, containing the ids of hidden shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        [Nullable]
        public IEnumerable<TraktUserHiddenItemsPostResponseNotFoundItem<TraktShowIds>> Shows { get; set; }

        /// <summary>
        /// A list of <see cref="TraktUserHiddenItemsPostResponseNotFoundItem{T}" />, containing the ids of hidden seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktUserHiddenItemsPostResponseNotFoundItem<TraktSeasonIds>> Seasons { get; set; }
    }
}

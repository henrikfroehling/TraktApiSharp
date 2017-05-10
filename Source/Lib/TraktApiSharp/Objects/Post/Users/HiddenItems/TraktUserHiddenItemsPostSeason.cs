namespace TraktApiSharp.Objects.Post.Users.HiddenItems
{
    using Get.Shows.Seasons;
    using Newtonsoft.Json;

    /// <summary>
    /// A Trakt hidden items post season, containing the required season ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public class TraktUserHiddenItemsPostSeason
    {
        /// <summary>Gets or sets the required show ids. See also <seealso cref="TraktSeasonIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktSeasonIds Ids { get; set; }
    }
}

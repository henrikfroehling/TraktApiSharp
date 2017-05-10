namespace TraktApiSharp.Objects.Post.Users.HiddenItems
{
    using Newtonsoft.Json;

    /// <summary>A Trakt hidden items post season, containing the required season number.</summary>
    public class TraktUserHiddenItemsPostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}

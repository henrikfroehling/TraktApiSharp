namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses
{
    using Newtonsoft.Json;

    /// <summary>A collection containing the number of movies, shows and seasons.</summary>
    public class TraktUserHiddenItemsPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        [JsonProperty(PropertyName = "movies")]
        public int? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        [JsonProperty(PropertyName = "shows")]
        public int? Shows { get; set; }

        /// <summary>Gets or sets the number of seasons.</summary>
        [JsonProperty(PropertyName = "seasons")]
        public int? Seasons { get; set; }
    }
}

namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A Trakt network.</summary>
    public class TraktNetwork
    {
        /// <summary>Gets or sets the network name.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "name")]
        [Nullable]
        public string Name { get; set; }
    }
}

namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A Trakt certification.</summary>
    public class TraktCertification
    {
        /// <summary>Gets or sets the certification name.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "name")]
        [Nullable]
        public string Name { get; set; }

        /// <summary>Gets or sets the certification slug.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "slug")]
        [Nullable]
        public string Slug { get; set; }

        /// <summary>Gets or sets the certification description.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "description")]
        [Nullable]
        public string Description { get; set; }
    }
}

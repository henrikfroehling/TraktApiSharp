namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection of Trakt certifications. See also <seealso cref="TraktCertification "/>.</summary>
    public class TraktCertifications
    {
        /// <summary>
        /// Gets or sets the certifications for the country code "us". See also <seealso cref="TraktCertification" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "us")]
        [Nullable]
        public IEnumerable<TraktCertification> US { get; set; }
    }
}

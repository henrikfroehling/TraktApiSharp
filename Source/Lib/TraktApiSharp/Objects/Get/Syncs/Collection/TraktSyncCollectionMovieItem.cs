﻿namespace TraktApiSharp.Objects.Get.Syncs.Collection
{
    using Basic;
    using Movies;
    using Newtonsoft.Json;
    using System;

    public class TraktSyncCollectionMovieItem
    {
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime CollectedAt { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public TraktMetadata Metadata { get; set; }
    }
}
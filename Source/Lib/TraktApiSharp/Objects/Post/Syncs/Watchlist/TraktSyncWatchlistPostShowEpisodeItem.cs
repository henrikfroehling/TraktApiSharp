﻿namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Newtonsoft.Json;

    public class TraktSyncWatchlistPostShowEpisodeItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}

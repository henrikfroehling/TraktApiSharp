﻿namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    /// <summary>A Trakt watchlist post episode, containing the required episode number.</summary>
    public class TraktSyncWatchlistPostShowEpisode : ITraktSyncWatchlistPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public int Number { get; set; }
    }
}

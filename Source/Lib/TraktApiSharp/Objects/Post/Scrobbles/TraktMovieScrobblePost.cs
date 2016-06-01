﻿namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Get.Movies;
    using Newtonsoft.Json;
    using System;

    public class TraktMovieScrobblePost : TraktScrobblePost
    {
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (Movie == null)
                throw new ArgumentException("movie not set");

            if (string.IsNullOrEmpty(Movie.Title))
                throw new ArgumentException("movie title not set");

            if (Movie.Year <= 0)
                throw new ArgumentException("movie year not set");

            if (Movie.Ids == null || !Movie.Ids.HasAnyId)
                throw new ArgumentException("movie ids not set");
        }
    }
}

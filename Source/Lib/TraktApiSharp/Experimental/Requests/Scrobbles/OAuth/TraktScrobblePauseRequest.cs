﻿namespace TraktApiSharp.Experimental.Requests.Scrobbles.OAuth
{
    using Base.Post;

    internal sealed class TraktScrobblePauseRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>
    {
        public TraktScrobblePauseRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "scrobble/pause";
    }
}

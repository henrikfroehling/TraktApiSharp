﻿namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Syncs.Responses.Json.Writer;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsRemovePostResponseObjectJsonWriter : AObjectJsonWriter<ITraktSyncRatingsRemovePostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncRatingsRemovePostResponse obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Deleted != null)
            {
                var syncPostResponseGroupObjectJsonWriter = new SyncPostResponseGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_RATINGS_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED, cancellationToken).ConfigureAwait(false);
                await syncPostResponseGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Deleted, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NotFound != null)
            {
                var syncRatingsPostResponseNotFoundGroupObjectJsonWriter = new SyncPostResponseNotFoundGroupObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_RATINGS_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostResponseNotFoundGroupObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.NotFound, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}

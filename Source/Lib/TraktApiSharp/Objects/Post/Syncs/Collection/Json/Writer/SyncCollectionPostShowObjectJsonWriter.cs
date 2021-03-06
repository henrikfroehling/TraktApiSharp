﻿namespace TraktApiSharp.Objects.Post.Syncs.Collection.Json.Writer
{
    using Basic.Json.Writer;
    using Extensions;
    using Get.Shows.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostShowObjectJsonWriter : AObjectJsonWriter<ITraktSyncCollectionPostShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncCollectionPostShow obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.CollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_COLLECTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_TITLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Year.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_YEAR, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Year, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var showIdsObjectJsonWriter = new ShowIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await showIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var syncCollectionPostShowSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktSyncCollectionPostShowSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await syncCollectionPostShowSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Metadata != null)
            {
                var metadataObjectJsonWriter = new MetadataObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_METADATA, cancellationToken).ConfigureAwait(false);
                await metadataObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Metadata, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}

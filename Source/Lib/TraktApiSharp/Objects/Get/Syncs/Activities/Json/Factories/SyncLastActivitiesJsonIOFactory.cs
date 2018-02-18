﻿namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;
    using System;

    internal class SyncLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncLastActivities>
    {
        public IObjectJsonReader<ITraktSyncLastActivities> CreateObjectReader() => new SyncLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncLastActivities> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncLastActivities)} is not supported.");

        public IObjectJsonWriter<ITraktSyncLastActivities> CreateObjectWriter() => new SyncLastActivitiesObjectJsonWriter();
    }
}

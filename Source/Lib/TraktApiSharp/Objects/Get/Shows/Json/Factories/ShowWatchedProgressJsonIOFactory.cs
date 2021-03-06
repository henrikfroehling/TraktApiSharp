﻿namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;
    using System;

    internal class ShowWatchedProgressJsonIOFactory : IJsonIOFactory<ITraktShowWatchedProgress>
    {
        public IObjectJsonReader<ITraktShowWatchedProgress> CreateObjectReader() => new ShowWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktShowWatchedProgress> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktShowWatchedProgress)} is not supported.");

        public IObjectJsonWriter<ITraktShowWatchedProgress> CreateObjectWriter() => new ShowWatchedProgressObjectJsonWriter();
    }
}

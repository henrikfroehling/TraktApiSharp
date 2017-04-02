﻿namespace TraktApiSharp.Objects.Get.Shows.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Shows;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktRecentlyUpdatedShowObjectJsonReader : ITraktObjectJsonReader<ITraktRecentlyUpdatedShow>
    {
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_SHOW = "show";

        public Task<ITraktRecentlyUpdatedShow> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktRecentlyUpdatedShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return null;

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ITraktShowObjectJsonReader();
                ITraktRecentlyUpdatedShow traktRecentlyUpdatedShow = new TraktRecentlyUpdatedShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktRecentlyUpdatedShow.RecentlyUpdatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_SHOW:
                            traktRecentlyUpdatedShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktRecentlyUpdatedShow;
            }

            return null;
        }
    }
}

﻿namespace TraktApiSharp.Objects.Post.Responses.Json.Reader
{
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundShowObjectJsonReader : AObjectJsonReader<ITraktPostResponseNotFoundShow>
    {
        public override async Task<ITraktPostResponseNotFoundShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPostResponseNotFoundShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showIdsReader = new ShowIdsObjectJsonReader();
                ITraktPostResponseNotFoundShow postResponseNotFoundShow = new TraktPostResponseNotFoundShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.POST_RESPONSE_NOT_FOUND_SHOW_PROPERTY_NAME_IDS:
                            postResponseNotFoundShow.Ids = await showIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return postResponseNotFoundShow;
            }

            return await Task.FromResult(default(ITraktPostResponseNotFoundShow));
        }
    }
}

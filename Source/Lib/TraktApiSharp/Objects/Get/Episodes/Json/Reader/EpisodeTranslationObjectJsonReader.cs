﻿namespace TraktApiSharp.Objects.Get.Episodes.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeTranslationObjectJsonReader : AObjectJsonReader<ITraktEpisodeTranslation>
    {
        public override async Task<ITraktEpisodeTranslation> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktEpisodeTranslation));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktEpisodeTranslation traktEpisodeTranslation = new TraktEpisodeTranslation();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.EPISODE_TRANSLATION_PROPERTY_NAME_TITLE:
                            traktEpisodeTranslation.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_TRANSLATION_PROPERTY_NAME_OVERVIEW:
                            traktEpisodeTranslation.Overview = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_TRANSLATION_PROPERTY_NAME_LANGUAGE_CODE:
                            traktEpisodeTranslation.LanguageCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktEpisodeTranslation;
            }

            return await Task.FromResult(default(ITraktEpisodeTranslation));
        }
    }
}

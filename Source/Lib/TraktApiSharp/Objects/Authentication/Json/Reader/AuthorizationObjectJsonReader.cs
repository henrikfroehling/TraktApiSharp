﻿namespace TraktApiSharp.Objects.Authentication.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktApiSharp.Enums;

    internal class AuthorizationObjectJsonReader : AObjectJsonReader<ITraktAuthorization>
    {
        public override async Task<ITraktAuthorization> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktAuthorization));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktAuthorization traktAuthorization = new TraktAuthorization();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.AUTHORIZATION_PROPERTY_NAME_ACCESS_TOKEN:
                            traktAuthorization.AccessToken = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.AUTHORIZATION_PROPERTY_NAME_REFRESH_TOKEN:
                            traktAuthorization.RefreshToken = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.AUTHORIZATION_PROPERTY_NAME_SCOPE:
                            traktAuthorization.Scope = await JsonReaderHelper.ReadEnumerationValueAsync<TraktAccessScope>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.AUTHORIZATION_PROPERTY_NAME_EXPIRES_IN:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktAuthorization.ExpiresInSeconds = value.Second;

                                break;
                            }
                        case JsonProperties.AUTHORIZATION_PROPERTY_NAME_TOKEN_TYPE:
                            traktAuthorization.TokenType = await JsonReaderHelper.ReadEnumerationValueAsync<TraktAccessTokenType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.AUTHORIZATION_PROPERTY_NAME_CREATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongIntegerAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktAuthorization.CreatedAtTimestamp = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktAuthorization;
            }

            return await Task.FromResult(default(ITraktAuthorization));
        }
    }
}

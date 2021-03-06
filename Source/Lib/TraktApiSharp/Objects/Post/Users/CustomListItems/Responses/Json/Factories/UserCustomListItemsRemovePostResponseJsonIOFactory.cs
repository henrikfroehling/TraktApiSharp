﻿namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class UserCustomListItemsRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateObjectReader()
            => new UserCustomListItemsRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsRemovePostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktUserCustomListItemsRemovePostResponse> CreateObjectWriter()
            => new UserCustomListItemsRemovePostResponseObjectJsonWriter();
    }
}

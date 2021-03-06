﻿namespace TraktApiSharp.Objects.Post.Users.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class UserFollowUserPostResponseJsonIOFactory : IJsonIOFactory<ITraktUserFollowUserPostResponse>
    {
        public IObjectJsonReader<ITraktUserFollowUserPostResponse> CreateObjectReader() => new UserFollowUserPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollowUserPostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserFollowUserPostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktUserFollowUserPostResponse> CreateObjectWriter() => new UserFollowUserPostResponseObjectJsonWriter();
    }
}

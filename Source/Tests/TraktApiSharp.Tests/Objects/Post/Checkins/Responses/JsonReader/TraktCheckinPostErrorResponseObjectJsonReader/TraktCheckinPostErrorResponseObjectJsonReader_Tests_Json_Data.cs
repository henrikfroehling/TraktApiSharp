﻿namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.JsonReader
{
    public partial class TraktCheckinPostErrorResponseObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""expires_at"": ""2016-04-01T12:44:40Z"",
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""ea"": ""2016-04-01T12:44:40Z"",
              }";
    }
}

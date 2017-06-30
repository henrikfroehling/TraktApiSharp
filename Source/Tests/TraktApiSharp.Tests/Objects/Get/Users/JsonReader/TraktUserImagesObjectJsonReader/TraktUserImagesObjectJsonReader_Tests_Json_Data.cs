﻿namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    public partial class TraktUserImagesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""avatar"": {
                  ""full"": ""https://walter.trakt.us/images/users/000/359/474/avatars/large/58cc281a20.gif""
                }
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""av"": {
                  ""full"": ""https://walter.trakt.us/images/users/000/359/474/avatars/large/58cc281a20.gif""
                }
              }";
    }
}

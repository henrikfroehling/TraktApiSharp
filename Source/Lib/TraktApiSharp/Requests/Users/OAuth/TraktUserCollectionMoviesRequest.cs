﻿namespace TraktApiSharp.Requests.Users.OAuth
{
    using Extensions;
    using Objects.Get.Collections;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktUserCollectionMoviesRequest : ATraktUsersGetRequest<ITraktCollectionMovie>
    {
        internal string Username { get; set; }

        public override string UriTemplate => "users/{username}/collection/movies{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));
        }
    }
}

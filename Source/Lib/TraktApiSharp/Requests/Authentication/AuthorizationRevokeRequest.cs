﻿namespace TraktApiSharp.Requests.Authentication
{
    using Requests.Base;
    using System.Collections.Generic;

    internal sealed class AuthorizationRevokeRequest : APostRequest<AuthorizationRevokeRequestBody>
    {
        public override string UriTemplate => "oauth/revoke";

        public override AuthorizationRevokeRequestBody RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}

namespace TraktApiSharp.Requests.WithoutOAuth.Networks
{
    using Base.Get;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktNetworksRequest : TraktGetRequest<IEnumerable<TraktNetwork>, TraktNetwork>
    {
        internal TraktNetworksRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool IsListResult => true;

        protected override string UriTemplate => "networks";
    }
}

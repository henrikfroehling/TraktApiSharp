﻿namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows;

    internal class TraktShowRelatedShowsRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktShow>, TraktShow>
    {
        internal TraktShowRelatedShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/related";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}

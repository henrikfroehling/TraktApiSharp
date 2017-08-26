﻿namespace TraktApiSharp.Requests.Shows
{
    using Objects.Get.Shows;

    internal sealed class TraktShowsMostAnticipatedRequest : AShowsRequest<ITraktMostAnticipatedShow>
    {
        public override string UriTemplate => "shows/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        public override void Validate() { }
    }
}

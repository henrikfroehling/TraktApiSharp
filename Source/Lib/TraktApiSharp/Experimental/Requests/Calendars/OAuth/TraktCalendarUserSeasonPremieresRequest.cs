﻿namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktCalendarUserSeasonPremieresRequest : ATraktCalendarUserRequest<TraktCalendarShow>
    {
        public TraktCalendarUserSeasonPremieresRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

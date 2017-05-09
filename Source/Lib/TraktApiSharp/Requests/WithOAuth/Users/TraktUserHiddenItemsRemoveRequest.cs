namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Post;
    using Enums;
    using Objects.Post.Users.HiddenItems;
    using Objects.Post.Users.HiddenItems.Responses;
    using System.Collections.Generic;

    internal class TraktUserHiddenItemsRemoveRequest : TraktPostRequest<TraktUsersHiddenItemsRemovePostResponse, TraktUsersHiddenItemsRemovePostResponse, TraktUsersHiddenItemsPost>
    {
        internal TraktUserHiddenItemsRemoveRequest(TraktClient client) : base(client) { }

        internal TraktHiddenItemsSection Section { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Section != null && Section != TraktHiddenItemsSection.Unspecified)
                uriParams.Add("section", Section.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "users/hidden/{section}/remove";
    }
}

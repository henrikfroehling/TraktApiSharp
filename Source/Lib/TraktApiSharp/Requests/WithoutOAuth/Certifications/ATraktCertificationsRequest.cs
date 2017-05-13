namespace TraktApiSharp.Requests.WithoutOAuth.Certifications
{
    using Base.Get;
    using Objects.Basic;

    internal abstract class ATraktCertificationsRequest : TraktGetRequest<TraktCertifications, TraktCertifications>
    {
        internal ATraktCertificationsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;
    }
}

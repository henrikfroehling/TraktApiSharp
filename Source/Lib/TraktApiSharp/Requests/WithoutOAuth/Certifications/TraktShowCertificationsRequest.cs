namespace TraktApiSharp.Requests.WithoutOAuth.Certifications
{
    internal class TraktShowCertificationsRequest : ATraktCertificationsRequest
    {
        internal TraktShowCertificationsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "certifications/shows";
    }
}

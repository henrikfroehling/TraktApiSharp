namespace TraktApiSharp.Requests.WithoutOAuth.Certifications
{
    internal class TraktMovieCertificationsRequest : ATraktCertificationsRequest
    {
        internal TraktMovieCertificationsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "certifications/movies";
    }
}

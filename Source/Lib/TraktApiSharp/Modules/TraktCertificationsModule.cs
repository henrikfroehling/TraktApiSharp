namespace TraktApiSharp.Modules
{
    using Attributes;
    using Exceptions;
    using Objects.Basic;
    using Requests.WithoutOAuth.Certifications;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to certifications.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/certifications">"Trakt API Doc - Certifications"</a> section.
    /// </para>
    /// </summary>
    public class TraktCertificationsModule : TraktBaseModule
    {
        internal TraktCertificationsModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets all movie certifications.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/certifications/list/get-certifications">"Trakt API Doc - Certifications: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <returns>An <see cref="TraktCertifications" /> instance with the queried certifications' data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktCertifications> GetMovieCertificationsAsync()
            => await QueryAsync(new TraktMovieCertificationsRequest(Client));

        /// <summary>
        /// Gets all show certifications.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/certifications/list/get-certifications">"Trakt API Doc - Certifications: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <returns>An <see cref="TraktCertifications" /> instance with the queried certifications' data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktCertifications> GetShowCertificationsAsync()
            => await QueryAsync(new TraktShowCertificationsRequest(Client));
    }
}

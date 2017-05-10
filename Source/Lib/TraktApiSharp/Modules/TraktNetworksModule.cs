namespace TraktApiSharp.Modules
{
    using Attributes;
    using Exceptions;
    using Objects.Basic;
    using Requests.WithoutOAuth.Networks;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to networks.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/networks">"Trakt API Doc - Networks"</a> section.
    /// </para>
    /// </summary>
    public class TraktNetworksModule : TraktBaseModule
    {
        internal TraktNetworksModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets a list of all networks.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/networks/list/get-networks">"Trakt API Doc - Networks: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <returns>A list of <see cref="TraktNetwork" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktNetwork>> GetNetworksAsync()
            => await QueryAsync(new TraktNetworksRequest(Client));
    }
}

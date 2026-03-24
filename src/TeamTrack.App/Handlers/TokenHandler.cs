
using Blazored.LocalStorage;
using TeamTrack.App.Models.Auth;
using System.Net.Http.Headers;

namespace TeamTrack.App.Handlers
{
    public class TokenHandler(ILocalStorageService storage) : DelegatingHandler
    {
        private readonly ILocalStorageService _storage = storage;

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // get token stored from login or switch-organization
            var loginResponse = await _storage.GetItemAsync<LoginResponseDto>("loginResponse");

            if (loginResponse?.Token is not null)
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", loginResponse.Token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

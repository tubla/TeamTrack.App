using Blazored.LocalStorage;

namespace TeamTrack.App.Handlers
{
    public class OrganizationHeaderHandler(ILocalStorageService storage) : DelegatingHandler
    {
        private readonly ILocalStorageService _storage = storage;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var orgId = await _storage.GetItemAsync<string>("organizationId",cancellationToken);

            if (!string.IsNullOrWhiteSpace(orgId))
                request.Headers.TryAddWithoutValidation("X-Organization-Id", orgId);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

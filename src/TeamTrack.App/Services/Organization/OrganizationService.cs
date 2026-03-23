using System.Net.Http.Json;
using TeamTrack.App.Models.Admin;
using TeamTrack.App.Models.Common;

namespace TeamTrack.App.Services.Organization
{
    public class OrganizationService(HttpClient http) : IOrganizationService
    {
        private readonly HttpClient _http = http;

        public async Task<List<AdminOwnedOrgVM>> GetOwnedOrganizationsAsync()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<AdminOwnedOrgVM>>>("organizations/my");

            return response?.Data ?? [];
        }
    }
}

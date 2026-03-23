using System.Net.Http.Json;
using TeamTrack.App.Models.Admin;
using TeamTrack.App.Models.Common;

namespace TeamTrack.App.Services.Role
{
    public class RoleService(HttpClient http) : IRoleService
    {
        private readonly HttpClient _http = http;

        public async Task<List<RoleVM>> GetRolesAsync()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<RoleVM>>>("roles");

            return response?.Data ?? [];
        }
    }
}

using System.Net.Http.Json;
using TeamTrack.App.Models.Admin;
using TeamTrack.App.Models.Common;

namespace TeamTrack.App.Services.Admin
{
    public class AdminAccessService(HttpClient http) : IAdminAccessService
    {
        private readonly HttpClient _http = http;

        public async Task<List<OrgAccessRequestViewModel>> GetPendingRequestsAsync()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<OrgAccessRequestViewModel>>>("org-access/pending");

            return response?.Data ?? new List<OrgAccessRequestViewModel>();
        }

        public async Task<ApiResponse<string>> ApproveRequestAsync(ApproveOrgAccessRequestDto dto)
        {
            var response = await _http.PostAsJsonAsync("org-access/approve", dto);

            return await response.Content.ReadFromJsonAsync<ApiResponse<string>>()
                   ?? new ApiResponse<string> { Success = false, Message = "Invalid server response." };
        }

        public async Task<ApiResponse<string>> RejectRequestAsync(Guid requestId)
        {
            var response = await _http.PostAsync($"org-access/reject/{requestId}", null);

            return await response.Content.ReadFromJsonAsync<ApiResponse<string>>()
                   ?? new ApiResponse<string> {Success = false, Message = "Invalid server response." };
        }
    }
}

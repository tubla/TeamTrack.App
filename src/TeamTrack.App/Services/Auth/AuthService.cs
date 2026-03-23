using System.Net.Http.Json;
using TeamTrack.App.Models.Auth;
using TeamTrack.App.Models.Common;

namespace TeamTrack.App.Services.Auth
{
    public class AuthService(HttpClient http) : IAuthService
    {
        private readonly HttpClient _http = http;

        public async Task<ApiResponse<RegisterResponseDto>> RegisterAsync(RegisterDto dto)
        {
            var response = await _http.PostAsJsonAsync("auth/register", dto);

            return await response.Content.ReadFromJsonAsync<ApiResponse<RegisterResponseDto>>()
                   ?? new ApiResponse<RegisterResponseDto> { Success = false, Message = "Invalid server response." };
        }


        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto dto)
        {
            var response = await _http.PostAsJsonAsync("auth/login", dto);
            return await response.Content.ReadFromJsonAsync<ApiResponse<LoginResponseDto>>()
                   ?? new ApiResponse<LoginResponseDto> { Success = false, Message = "Invalid server response." };
        }

        public async Task<ApiResponse<SwitchOrganizationResponseDto>> SwitchOrganizationAsync(SwitchOrganizationDto dto)
        {
            var response = await _http.PostAsJsonAsync("auth/switch-organization", dto);

            return await response.Content.ReadFromJsonAsync<ApiResponse<SwitchOrganizationResponseDto>>()
                   ?? new ApiResponse<SwitchOrganizationResponseDto> { Success = false, Message = "Invalid server response." };
        }

        public async Task<ApiResponse<string>> RequestOrgAccessAsync(OrgAccessRequestDto dto)
        {
            var response = await _http.PostAsJsonAsync("org-access/request", dto);

            return await response.Content.ReadFromJsonAsync<ApiResponse<string>>()
                   ?? new ApiResponse<string> { Success = false, Message = "Invalid server response." };
        }
    }

}

using TeamTrack.App.Models.Auth;
using TeamTrack.App.Models.Common;

namespace TeamTrack.App.Services.Auth
{
    public interface IAuthService
    {
        Task<ApiResponse<RegisterResponseDto>> RegisterAsync(RegisterDto dto);
        Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto dto);
        Task<ApiResponse<SwitchOrganizationResponseDto>> SwitchOrganizationAsync(SwitchOrganizationDto dto);
        Task<ApiResponse<string>> RequestOrgAccessAsync(OrgAccessRequestDto dto);
    }

}

using TeamTrack.App.Models.Organization;

namespace TeamTrack.App.Models.Auth
{

    public class LoginResponseDto
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }

        public UserInfoDto? User { get; set; }
        public List<OrganizationDto>? Organizations { get; set; }
    }

}

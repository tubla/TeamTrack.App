namespace TeamTrack.App.Models.Auth
{
    public class OrgAccessRequestDto
    {
        public string Email { get; set; } = default!;
        public string? Message { get; set; }
    }
}

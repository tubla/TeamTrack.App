namespace TeamTrack.App.Models.Auth
{

    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public Guid? CurrentOrganizationId { get; set; }
        public string? CurrentOrganizationName { get; set; }

        public List<string>? Permissions { get; set; }
        public List<string>? Roles { get; set; }
    }

}

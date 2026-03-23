namespace TeamTrack.App.Models.Admin
{
    public class OrgAccessRequestViewModel
    {
        public Guid Id { get; set; }           // This MUST map to OrgAccessRequests.Id
        public string Email { get; set; } = "";
        public string? Message { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

}

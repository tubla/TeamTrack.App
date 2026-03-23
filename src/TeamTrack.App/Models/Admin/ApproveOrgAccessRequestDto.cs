namespace TeamTrack.App.Models.Admin
{

    public class ApproveOrgAccessRequestDto
    {
        public Guid RequestId { get; set; }
        public List<OrgAssignmentDto> Assignments { get; set; } = new();
    }

}

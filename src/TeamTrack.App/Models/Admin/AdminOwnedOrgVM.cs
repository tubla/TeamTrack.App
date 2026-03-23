namespace TeamTrack.App.Models.Admin
{
    public class AdminOwnedOrgVM
    {
        public Guid Id { get; set; }           // OrganizationId
        public string Name { get; set; } = "";
        public bool IsSelected { get; set; } = false;
        public Guid RoleId { get; set; }       // Selected role
    }
}

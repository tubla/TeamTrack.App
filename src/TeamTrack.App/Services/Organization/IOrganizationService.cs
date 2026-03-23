using TeamTrack.App.Models.Admin;

namespace TeamTrack.App.Services.Organization
{
    public interface IOrganizationService
    {
        Task<List<AdminOwnedOrgVM>> GetOwnedOrganizationsAsync();
    }

}

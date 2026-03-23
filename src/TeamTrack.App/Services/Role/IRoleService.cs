using TeamTrack.App.Models.Admin;

namespace TeamTrack.App.Services.Role
{
    public interface IRoleService
    {
        Task<List<RoleVM>> GetRolesAsync();
    }
}

using TeamTrack.App.Models.Admin;
using TeamTrack.App.Models.Common;

namespace TeamTrack.App.Services.Admin
{
    public interface IAdminAccessService
    {
        Task<List<OrgAccessRequestViewModel>> GetPendingRequestsAsync();
        Task<ApiResponse<string>> ApproveRequestAsync(ApproveOrgAccessRequestDto dto);
        Task<ApiResponse<string>> RejectRequestAsync(Guid requestId);
    }

}

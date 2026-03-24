using TeamTrack.App.Models.Common;
using TeamTrack.App.Models.Dashboard;

namespace TeamTrack.App.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<ApiResponse<DashboardData>> GetDashboardAsync();
    }
}

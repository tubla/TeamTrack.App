using TeamTrack.App.Models.Common;
using TeamTrack.App.Models.Project;

namespace TeamTrack.App.Services.Project
{
    public interface IProjectService
    {
        Task<ApiResponse<PagedResponse<ProjectDto>>> GetProjectsAsync(int page = 1, int pageSize = 10, string? search = null);
        Task<ApiResponse<ProjectDto>> GetProjectAsync(Guid id);
        Task<ApiResponse<ProjectDto>> CreateProjectAsync(CreateProjectDto dto);
        Task<ApiResponse<ProjectDto>> UpdateProjectAsync(Guid id, UpdateProjectDto dto);
        Task<ApiResponse<bool>> DeleteProjectAsync(Guid id);
    }
}

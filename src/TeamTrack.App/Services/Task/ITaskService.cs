using TeamTrack.App.Models.Common;
using TeamTrack.App.Models.Task;

namespace TeamTrack.App.Services.Task
{
    public interface ITaskService
    {
        Task<ApiResponse<PagedResponse<TaskDto>>> GetTasksAsync(
        Guid projectId,
        int page,
        int pageSize);

        Task<ApiResponse<TaskDto>> CreateTaskAsync(CreateTaskDto dto);

        Task<ApiResponse<bool>> UpdateTaskStatusAsync(Guid taskId, string status);
    }
}
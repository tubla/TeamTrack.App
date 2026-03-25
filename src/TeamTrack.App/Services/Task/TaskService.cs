using System.Net.Http.Json;
using MudBlazor;
using TeamTrack.App.Models.Common;
using TeamTrack.App.Models.Task;
using TeamTrack.App.Services.Task;

public class TaskService(HttpClient http, ISnackbar snackbar) : ITaskService
{
    private readonly HttpClient _http = http;
    private readonly ISnackbar _snackbar = snackbar;


    public async Task<ApiResponse<PagedResponse<TaskDto>>> GetTasksAsync(
    Guid projectId,
    int page,
    int pageSize)
    {
        var url = $"tasks?projectId={projectId}&page={page}&pageSize={pageSize}";

        var response = await _http.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ApiResponse<PagedResponse<TaskDto>>>()
                   ?? new ApiResponse<PagedResponse<TaskDto>>();
        }

        _snackbar.Add("Failed to load tasks", Severity.Error);
        return new ApiResponse<PagedResponse<TaskDto>>();
    }

    public async Task<ApiResponse<TaskDto>> CreateTaskAsync(CreateTaskDto dto)
    {
        var response = await _http.PostAsJsonAsync("tasks", dto);

        return await response.Content.ReadFromJsonAsync<ApiResponse<TaskDto>>()
               ?? new ApiResponse<TaskDto> { Success = false };

    }

    public async Task<ApiResponse<bool>> UpdateTaskStatusAsync(Guid taskId, string status)
    {
        var response = await _http.PutAsJsonAsync($"tasks/{taskId}/status", new { Status = status });

        return await response.Content.ReadFromJsonAsync<ApiResponse<bool>>()
               ?? new ApiResponse<bool> { Success = false };
    }


}

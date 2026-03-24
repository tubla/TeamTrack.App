using MudBlazor;
using System.Net.Http.Json;
using TeamTrack.App.Extensions;
using TeamTrack.App.Models.Common;
using TeamTrack.App.Models.Project;

namespace TeamTrack.App.Services.Project;

public class ProjectService(HttpClient httpClient, ISnackbar snackbar) : IProjectService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ISnackbar _snackbar = snackbar;

    public async Task<ApiResponse<PagedResponse<ProjectDto>>> GetProjectsAsync(int page = 1, int pageSize = 10, string? search = null)
    {
        var url = $"projects?page={page}&pageSize={pageSize}";
        if (!string.IsNullOrWhiteSpace(search))
            url += $"&search={Uri.EscapeDataString(search)}";

        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync< ApiResponse<PagedResponse<ProjectDto>>>();
            return result ?? new ApiResponse<PagedResponse<ProjectDto>>();
        }

        _snackbar.Add("Failed to load projects", Severity.Error);
        return new ApiResponse<PagedResponse<ProjectDto>>();
    }

    public async Task<ApiResponse<ProjectDto>> CreateProjectAsync(CreateProjectDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("projects", dto);
        return await response.HandleApiResponse<ProjectDto>(_snackbar);
    }

    public async Task<ApiResponse<ProjectDto>> UpdateProjectAsync(Guid id, UpdateProjectDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"projects/{id}", dto);
        return await response.HandleApiResponse<ProjectDto>(_snackbar);
    }

    public async Task<ApiResponse<bool>> DeleteProjectAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"projects/{id}");
        return await response.HandleApiResponse<bool>(_snackbar);
    }
}
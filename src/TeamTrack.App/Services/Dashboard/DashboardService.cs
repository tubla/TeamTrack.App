using MudBlazor;
using System.Net.Http.Json;
using TeamTrack.App.Models.Common;
using TeamTrack.App.Models.Dashboard;

namespace TeamTrack.App.Services.Dashboard;

public class DashboardService(HttpClient httpClient, ISnackbar snackbar) : IDashboardService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ISnackbar _snackbar = snackbar;

    public async Task<ApiResponse<DashboardData>> GetDashboardAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("dashboard");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<DashboardData>>();
                return result ?? new ApiResponse<DashboardData> { Success = false, Message = "Empty response" };
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            var errorResponse = await response.Content.ReadFromJsonAsync<ApiResponse<DashboardData>>();

            if (errorResponse != null)
            {
                return errorResponse;
            }

            return new ApiResponse<DashboardData>
            {
                Success = false,
                Message = $"HTTP {(int)response.StatusCode}: {response.ReasonPhrase}",
                Errors = [errorContent]
            };
        }
        catch (Exception ex)
        {
            _snackbar.Add($"Failed to load dashboard: {ex.Message}", Severity.Error);
            return new ApiResponse<DashboardData>
            {
                Success = false,
                Message = ex.Message
            };
        }
    }
}
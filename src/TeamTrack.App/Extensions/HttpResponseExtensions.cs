using MudBlazor;
using System.Net.Http.Json;
using TeamTrack.App.Models.Common;

namespace TeamTrack.App.Extensions;

public static class HttpResponseExtensions
{
    /// <summary>
    /// Standardized way to handle HTTP responses and convert them to ApiResponse<T>
    /// </summary>
    public static async Task<ApiResponse<T>> HandleApiResponse<T>(this HttpResponseMessage response, ISnackbar? snackbar = null)
    {
        try
        {
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<T>();

                return new ApiResponse<T>
                {
                    Success = true,
                    Data = data,
                    Message = "Operation completed successfully"
                };
            }
            else
            {
                // Try to read error response from backend
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiResponse<T>>();

                if (errorResponse != null && !string.IsNullOrEmpty(errorResponse.Message))
                {
                    snackbar?.Add(errorResponse.Message, Severity.Error);
                    return errorResponse;
                }

                // Fallback error
                var errorContent = await response.Content.ReadAsStringAsync();
                var errorMessage = $"Error {(int)response.StatusCode}: {response.ReasonPhrase}";

                snackbar?.Add(errorMessage, Severity.Error);

                return new ApiResponse<T>
                {
                    Success = false,
                    Message = errorMessage,
                    StatusCode = (int)response.StatusCode,
                    Errors = [errorContent]
                };
            }
        }
        catch (Exception ex)
        {
            var errorMsg = $"Unexpected error: {ex.Message}";
            snackbar?.Add(errorMsg, Severity.Error);

            return new ApiResponse<T>
            {
                Success = false,
                Message = errorMsg
            };
        }
    }
}
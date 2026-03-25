using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace TeamTrack.App.Shared
{
    public abstract class BasePageComponent : ComponentBase
    {
        [Inject] protected ISnackbar Snackbar { get; set; } = default!;
        [Inject] protected NavigationManager Nav { get; set; } = default!;


        protected bool IsLoading { get; set; }

        // ================= GLOBAL LOADING =================

        protected async Task ExecuteSafeAsync(Func<Task> action, string? errorMessage = null)
        {
            try
            {
                IsLoading = true;
                StateHasChanged();

                await action();
            }
            catch (Exception ex)
            {
                Snackbar.Add(errorMessage ?? "Something went wrong", Severity.Error);
                Console.Error.WriteLine($"[ERROR]: {ex}");
            }
            finally
            {
                IsLoading = false;
                StateHasChanged();
            }
        }

        protected async Task<T?> ExecuteSafeAsync<T>(Func<Task<T>> action, string? errorMessage = null)
        {
            try
            {
                IsLoading = true;
                StateHasChanged();

                return await action();
            }
            catch (Exception ex)
            {
                Snackbar.Add(errorMessage ?? "Something went wrong", Severity.Error);
                Console.Error.WriteLine($"[ERROR]: {ex}");
                return default;
            }
            finally
            {
                IsLoading = false;
                StateHasChanged();
            }
        }

        // ================= NO LOADING =================

        protected async Task ExecuteSafeNoLoadingAsync(Func<Task> action, string? errorMessage = null)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                Snackbar.Add(errorMessage ?? "Something went wrong", Severity.Error);
                Console.Error.WriteLine($"[ERROR]: {ex}");
            }
        }

        protected async Task<T?> ExecuteSafeNoLoadingAsync<T>(Func<Task<T>> action, string? errorMessage = null)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                Snackbar.Add(errorMessage ?? "Something went wrong", Severity.Error);
                Console.Error.WriteLine($"[ERROR]: {ex}");
                return default;
            }
        }

        // ================= CUSTOM LOADING =================

        protected async Task ExecuteWithLoadingAsync(
            Func<Task> action,
            Action<bool> setLoading,
            string? errorMessage = null)
        {
            try
            {
                setLoading(true);
                StateHasChanged();

                await action();
            }
            catch (Exception ex)
            {
                Snackbar.Add(errorMessage ?? "Something went wrong", Severity.Error);
                Console.Error.WriteLine($"[ERROR]: {ex}");
            }
            finally
            {
                setLoading(false);
                StateHasChanged();
            }
        }

        protected async Task<T?> ExecuteWithLoadingAsync<T>(
            Func<Task<T>> action,
            Action<bool> setLoading,
            string? errorMessage = null)
        {
            try
            {
                setLoading(true);
                StateHasChanged();

                return await action();
            }
            catch (Exception ex)
            {
                Snackbar.Add(errorMessage ?? "Something went wrong", Severity.Error);
                Console.Error.WriteLine($"[ERROR]: {ex}");
                return default;
            }
            finally
            {
                setLoading(false);
                StateHasChanged();
            }
        }
    }
}
namespace TeamTrack.App.Models.Dashboard
{
    public class DashboardData
    {
        public DashboardStats Stats { get; set; } = new();
        public List<RecentTaskItem> RecentTasks { get; set; } = new();
        public List<ProjectProgressItem> ProjectProgress { get; set; } = new();
        public TaskDistribution TaskDistribution { get; set; } = new();
    }
}

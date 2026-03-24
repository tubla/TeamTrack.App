namespace TeamTrack.App.Models.Dashboard
{
    public class ProjectProgressItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int ProgressPercent { get; set; }
    }
}

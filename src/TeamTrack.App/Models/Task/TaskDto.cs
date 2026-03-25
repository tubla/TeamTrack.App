namespace TeamTrack.App.Models.Task
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? AssignedUserName { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

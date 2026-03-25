namespace TeamTrack.App.Models.Task
{
    public class CreateTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Todo;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public Guid? AssignedUserId { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid ProjectId { get; set; }
    }
}

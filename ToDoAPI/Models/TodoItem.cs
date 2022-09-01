namespace ToDoAPI.Models
{
    public class TodoItem : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ActivityTypeEnum? ActivityType { get; set; }
        public bool? IsComplete { get; set; }
    }

    public enum ActivityTypeEnum
    {
        Productive = 0,
        Relaxing = 1,
        Wasting = 2
    }
}

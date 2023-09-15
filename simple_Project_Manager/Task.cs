namespace SimpleTaskManager
{
    public enum TaskCategory
    {
        Personal,
        Work,
        Errands
        // Add more categories as needed
    }

    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskCategory Category { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            string completionStatus = IsCompleted ? "[Completed]" : "[Not Completed]";
            return $"{Name} - {Description} ({Category}) {completionStatus}";
        }
    }
}
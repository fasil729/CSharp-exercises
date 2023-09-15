using System.Collections.Generic;
using System.Linq;

namespace SimpleTaskManager
{
    public class TaskManager
    {
        private List<Task> tasks;

        public TaskManager()
        {
            tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public List<Task> GetAllTasks()
        {
            return tasks;
        }

        public List<Task> GetTasksByCategory(TaskCategory category)
        {
            return tasks.Where(t => t.Category == category).ToList();
        }

        public Task GetTaskByName(string taskName)
        {
            return tasks.FirstOrDefault(task => task.Name == taskName);
        }
    }
}
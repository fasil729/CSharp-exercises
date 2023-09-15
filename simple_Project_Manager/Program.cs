using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTaskManager
{
    class Program
    {
        static TaskManager taskManager;
        static string filePath = "tasks.csv";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Simple Task Manager!");

            taskManager = new TaskManager();

            LoadTasksFromFileAsync();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. View all tasks");
                Console.WriteLine("3. View tasks by category");
                Console.WriteLine("4. Update the task");
                Console.WriteLine("5. Exit");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewAllTasks();
                        break;
                    case "3":
                        ViewTasksByCategory();
                        break;
                    case "4":
                        UpdateTask();
                        break;
                    case "5":
                        SaveTasksToFileAsync();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for using the Simple Task Manager!");
        }

        static async void LoadTasksFromFileAsync()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            string[] taskData = line.Split(',');
                            if (taskData.Length == 4)
                            {
                                Task task = new Task
                                {
                                    Name = taskData[0],
                                    Description = taskData[1],
                                    Category = (TaskCategory)Enum.Parse(typeof(TaskCategory), taskData[2]),
                                    IsCompleted = bool.Parse(taskData[3])
                                };
                                taskManager.AddTask(task);
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while reading the tasks file: {ex.Message}");
            }
        }

        static async void SaveTasksToFileAsync()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Task task in taskManager.GetAllTasks())
                    {
                        await writer.WriteLineAsync($"{task.Name},{task.Description},{task.Category},{task.IsCompleted}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while saving the tasks file: {ex.Message}");
            }
        }

        static async void AddTask()
        {
            Console.WriteLine("Please enter the task details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Categories:");
            foreach (TaskCategory category in Enum.GetValues(typeof(TaskCategory)))
            {
                Console.WriteLine($"{(int)category}. {category}");
            }

            Console.Write("Category: ");
            if (Enum.TryParse(typeof(TaskCategory), Console.ReadLine(), out object categoryObj))
            {
                TaskCategory category = (TaskCategory)categoryObj;

                Task task = new Task
                {
                    Name = name,
                    Description = description,
                    Category = category
                };

                taskManager.AddTask(task);
                Console.WriteLine("Task added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid category. Task not added.");
            }

            SaveTasksToFileAsync();
        }

        static void UpdateTask()
        {
            Console.WriteLine("Please enter the name of the task you want to update:");
            string taskName = Console.ReadLine();

            Task taskToUpdate = taskManager.GetTaskByName(taskName);
            if (taskToUpdate != null)
            {
                Console.WriteLine("Please enter the updated details:");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Description: ");
                string description = Console.ReadLine();

                Console.WriteLine("Categories:");
                foreach (TaskCategory category in Enum.GetValues(typeof(TaskCategory)))
                {
                    Console.WriteLine($"{(int)category}. {category}");
                }

                Console.Write("Category: ");
                if (Enum.TryParse(typeof(TaskCategory), Console.ReadLine(), out object categoryObj))
                {
                    TaskCategory category = (TaskCategory)categoryObj;

                    taskToUpdate.Name = name;
                    taskToUpdate.Description = description;
                    taskToUpdate.Category = category;

                    Console.WriteLine("Task updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid category. Task not updated.");
                }
            }
    else
    {
        Console.WriteLine("Task not found.");
    }
}

        static void ViewAllTasks()
        {
            List<Task> tasks = taskManager.GetAllTasks();
            if (tasks.Count > 0)
            {
                Console.WriteLine("All Tasks:");
                foreach (Task task in tasks)
                {
                    Console.WriteLine(task.ToString());
                }
            }
            else
            {
                Console.WriteLine("No tasks found.");
            }
        }

        static async void ViewTasksByCategory()
        {
            Console.WriteLine("Please select a category to view tasks:");
            foreach (TaskCategory category in Enum.GetValues(typeof(TaskCategory)))
            {
                Console.WriteLine($"{(int)category}. {category}");
            }

            if (Enum.TryParse(typeof(TaskCategory), Console.ReadLine(), out object categoryObj))
            {
                TaskCategory category = (TaskCategory)categoryObj;

                List<Task> tasks = taskManager.GetTasksByCategory(category);
                if (tasks.Count > 0)
                {
                    Console.WriteLine($"Tasks in the {category} category:");
                    foreach (Task task in tasks)
                    {
                        Console.WriteLine(task.ToString());
                    }
                }
                else
                {
                    Console.WriteLine($"No tasks found in the {category} category.");
                }
            }
            else
            {
                Console.WriteLine("Invalid category.");
            }
        }
    }
}

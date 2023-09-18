using Newtonsoft.Json;
using System;
using System.IO;

enum MenuOption
{
    AddStudent = 1,
    SearchStudent,
    DisplayAllStudents,
    SaveStudentsToJson,
    LoadStudentsFromJson,
    Exit
}

class Menu
{
    private readonly StudentManager studentManager;

    public Menu(StudentManager studentManager)
    {
        this.studentManager = studentManager;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Student Management System");
        Console.WriteLine("-------------------------");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Search Student");
        Console.WriteLine("3. Display All Students");
        Console.WriteLine("4. Save Students to JSON");
        Console.WriteLine("5. Load Students from JSON");
        Console.WriteLine("6. Exit");
        Console.WriteLine();
        Console.Write("Enter your choice (1-6): ");
    }

    public MenuOption GetChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(MenuOption), choice))
        {
            Console.WriteLine("Invalid choice. Please try again.");
            Console.Write("Enter your choice (1-6): ");
        }

        return (MenuOption)choice;
    }

    public void AddStudent()
    {
        Console.WriteLine("Add Student");
        Console.WriteLine("-------------------------");

        Console.Write("Enter Name: ");
        var name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
        {
            Console.WriteLine("Invalid age. Please enter a positive integer.");
            Console.Write("Enter Age: ");
        }

        Console.Write("Enter Grade: ");
        var grade = Console.ReadLine();

        var student = new Student(name, age, grade);
        studentManager.AddStudent(student);
        SaveStudentsToJson();

        Console.WriteLine("Student added successfully.");
    }

    public void SearchStudent()
    {
        Console.WriteLine("Search Student");
        Console.WriteLine("-------------------------");

        Console.Write("Enter Name or ID: ");
        var searchQuery = Console.ReadLine();

        var results = studentManager.SearchStudent(searchQuery);

        if (results.Any())
        {
            Console.WriteLine("Search Results:");
            foreach (var student in results)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine("No students found for the given search criteria.");
        }
    }

    public void DisplayAllStudents()
    {
        LoadStudentsFromJson();
        Console.WriteLine("All Students");
        Console.WriteLine("-------------------------");

        var students = studentManager.GetAllStudents();

        if (students.Any())
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine("No students found.");
        }
    }
    public void SaveStudentsToJson()
    {
        var filePath = "storage.json";

        try
        {
            var jsonData = JsonConvert.SerializeObject(studentManager.GetAllStudents(), Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Students saved to JSON successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void LoadStudentsFromJson()
    {
        
        var filePath = "storage.json";

        try
        {
            var jsonData = File.ReadAllText(filePath);
            var loadedStudents = JsonConvert.DeserializeObject<StudentList<Student>>(jsonData);
            studentManager.ClearStudents();
            studentManager.AddStudents(loadedStudents);
            Console.WriteLine("Students loaded from JSON successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
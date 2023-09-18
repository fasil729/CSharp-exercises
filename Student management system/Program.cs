using System;

class Program
{
    static void Main()
    {
        var studentManager = new StudentManager();
        var menu = new Menu(studentManager);

        while (true)
        {
            menu.DisplayMenu();
            var choice = menu.GetChoice();

            switch (choice)
            {
                case MenuOption.AddStudent:
                    menu.AddStudent();
                    break;
                case MenuOption.SearchStudent:
                    menu.SearchStudent();
                    break;
                case MenuOption.DisplayAllStudents:
                    menu.DisplayAllStudents();
                    break;
                case MenuOption.SaveStudentsToJson:
                    menu.SaveStudentsToJson();
                    break;
                case MenuOption.LoadStudentsFromJson:
                    menu.LoadStudentsFromJson();
                    break;
                case MenuOption.Exit:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}

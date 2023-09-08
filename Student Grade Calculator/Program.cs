// See https://aka.ms/new-console-template for more information
using System;

// take input
Console.WriteLine("Welcome to the Student Grade Calculator!");

Console.WriteLine("Please enter your name: ");
string name = Console.ReadLine();
Console.WriteLine("Please enter the number of subjects: ");
string s = Console.ReadLine();
int sub = int.Parse(s);
Dictionary<string, int> subjects = new Dictionary<string, int>();
for (int i = 1; i <= sub; i++) 
{
   Console.WriteLine($"Subject {i} Name: "); 
   string subject = Console.ReadLine();
   Console.WriteLine("Grade: "); 
   int grade = int.Parse(Console.ReadLine());
   if (grade >= 0 && grade <= 100) 
   {
    subjects[subject] = grade;

   }
   else {
      Console.WriteLine("In correct Input!!! Please Enter the grade beteween 0 and 100 !!!");
      i--; 
   }
}

// printing the output
Console.WriteLine("");
Console.WriteLine("Calculating average grade...");
Console.WriteLine("");
Console.WriteLine($"Student: {name}");
Console.WriteLine("");
Console.WriteLine("Subject Grades: ");

foreach (KeyValuePair<string, int> pair in subjects)
{

    Console.WriteLine($"- {pair.Key}: {pair.Value}");
}

Console.WriteLine("");


Console.WriteLine($"Average Grade: {getAverage(subjects)}");

Console.WriteLine("");
Console.WriteLine("Thank you for using the Student Grade Calculator!");



int getAverage(Dictionary<string, int> subjects)
{
    int tot = 0;
    int num = 0;
    foreach (KeyValuePair<string, int> pair in subjects)
    {

        tot += pair.Value;
        num++;
    }
    return tot / num;
}


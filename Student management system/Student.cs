using System;

class Student
{
    public string Name { get; }
    public int Age { get; }
    public string RollNumber { get; }
    public string Grade { get; }

    public Student(string name, int age, string grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
        RollNumber = GenerateRollNumber();
    }

    private string GenerateRollNumber()
    {
        var random = new Random();
        return $"RN-{random.Next(1000, 9999)}";
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Roll Number: {RollNumber}, Grade: {Grade}";
    }
}
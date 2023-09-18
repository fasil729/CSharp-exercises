using System.Collections.Generic;
using System.Linq;

class StudentManager
{
    private readonly StudentList<Student> studentList;

    public StudentManager()
    {
        studentList = new StudentList<Student>();
    }

    public void AddStudent(Student student)
    {
        studentList.Add(student);
    }

    public IEnumerable<Student> SearchStudent(string searchQuery)
    {
        return studentList.Search(searchQuery);
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return studentList;
    }

    public void ClearStudents()
    {
        studentList.Clear();
    }

    public void AddStudents(IEnumerable<Student> students)
    {
        studentList.AddRange(students);
    }
}
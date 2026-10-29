using Application.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class StudentService(StudentRepository studentRepository) : IStudentServices
{
    private StudentRepository studentRepository1 = studentRepository;
    public void AddStudent(Students student)
    {
        var result=studentRepository1.AddStudent(student);
        if(result)Console.WriteLine("Added successfully!");
        else Console.WriteLine("added nashud!");
    }

    public void DeleteStudent(int studentId)
    {
        var result=studentRepository1.DeleteStudent(studentId);
        if(result)Console.WriteLine("Delete successfully!");
        else Console.WriteLine("Delete nashud!");
    }

    public void GetAllStudents()
    {
        var result=studentRepository1.GetStudents();
        foreach(var s in result)
        {
            Console.WriteLine(s.Id+" "+s.Fullname+" "+s.Email+" "+s.Phone+" "+s.EnrollmentDate);
        }
    }

    public void GetStudent(int studentId)
    {
        var result=studentRepository1.GetStudent(studentId);
        Console.WriteLine(result.Id+" "+result.Fullname+" "+result.Email+" "+result.Phone+" "+result.EnrollmentDate);
    }

    public void UpdateStudent(Students student)
    {
        var result=studentRepository1.UpdateStudent(student);
        if(result)Console.WriteLine("Update successfully!");
        else Console.WriteLine("update nashud!");
    }

}

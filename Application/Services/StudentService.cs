using Application.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class StudentService(StudentRepository studentRepository) : IStudentServices
{
    private StudentRepository studentRepository1 = studentRepository;
    public async Task AddStudent(Students student)
    {
        var result=await studentRepository1.AddStudent(student);
        if(result)Console.WriteLine("Added successfully!");
        else Console.WriteLine("added nashud!");
    }

    public async Task DeleteStudent(int studentId)
    {
        var result=await studentRepository1.DeleteStudent(studentId);
        if(result)Console.WriteLine("Delete successfully!");
        else Console.WriteLine("Delete nashud!");
    }

    public async Task GetAllStudents()
    {
        var result=await studentRepository1.GetStudents();
        foreach(var s in result)
        {
            Console.WriteLine(s.Id+" "+s.Fullname+" "+s.Email+" "+s.Phone+" "+s.EnrollmentDate);
        }
    }

    public async Task<List<Students>> GetDroppedOutStudents()
    {
        return await studentRepository1.GetDroppedOutStudents();
    }

    public async Task<List<Students>> GetGraduatedStudents()
    {
        return await studentRepository1.GetGraduatedStudents();
    }


    public async Task GetStudent(int studentId)
    {
        var result=await studentRepository1.GetStudent(studentId);
        Console.WriteLine(result.Id+" "+result.Fullname+" "+result.Email+" "+result.Phone+" "+result.EnrollmentDate);
    }

    public async Task<List<Students>> GetStudentsWithGroups()
    {
        return await studentRepository1.GetStudentsWithGroups();
    }

    public async Task<List<Students>> GetStudentsWithoutGroups()
    {
        return await studentRepository1.GetStudentsWithoutGroups();
    }


    public async Task UpdateStudent(Students student)
    {
        var result=await studentRepository1.UpdateStudent(student);
        if(result)Console.WriteLine("Update successfully!");
        else Console.WriteLine("update nashud!");
    }

}

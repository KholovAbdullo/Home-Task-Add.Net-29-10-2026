namespace Application.DTOs.Students;

public class UpdateStudentDto
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateOnly EnrollmentDate { get; set; }
}

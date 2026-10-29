using Infrastructure.Repository;
using Infrastructure.Data;
using Application.Services;
using Domain.Models;
using Domain.Enames;

var Database = new Database();
var StudentRepository = new StudentRepository(Database);
var studentService=new StudentService(StudentRepository);
var coursesRepository=new CourseRepository(Database);
var courseService=new CourseService(coursesRepository);
var mentorsrepository = new MentorRepository(Database);
var mentorService = new MentorService(mentorsrepository);
var groupRepository = new GroupsRepository(Database);
var groupService = new GroupsService(groupRepository);
var studentgroupRepository = new StudentGroupRepository(Database);
var studentgroupService = new StudentGroupsService(studentgroupRepository);
while (true)
{
    Console.WriteLine("==================================");
    Console.WriteLine(@"
    Table Students!.
    1 - Show all students.
    2 - Show student.
    3 - Add new student.
    4 - Update student.
    5 - Delete student.

    Table Courses!
    6 - Show all courses.
    7 - Show course.
    8 - Add new course.
    9 - Update course.
    10 - Delete course.

    Table Mentors!
    11 - Show all mentors.
    12 - Show mentor.
    13 - Add new mentors.
    14 - Update mentors.
    15 - Delete mentors.

    Table Groups!
    16 - Show all groups.
    17 - Show groups.
    18 - Add new groups.
    19 - Update groups.
    20 - Delete groups.

    Table StudentGroups!
    21 - Show all studentgroups.
    22 - Show studentgroups.
    23 - Add new studentgroups.
    24 - Update studentgroups.
    25 - Delete studentgroups.
    0 - Exit.");
    var option = Console.ReadLine();
    Console.WriteLine("==================================");

    switch (option)
    {
        case "1":
            await studentService.GetAllStudents();
            break;
        case "2":
            Console.Write("Enter id: ");
            var student_id = Convert.ToInt32(Console.ReadLine());
            await studentService.GetStudent(student_id);
            break;
        case "3":
            Console.Write("Enter fullname: ");
            var fullname = Console.ReadLine()!;
            Console.Write("Enter email: ");
            var email = Console.ReadLine()!;
            Console.Write("Enter phone: ");
            var phone = Console.ReadLine()!;
            Console.Write("Enter enrollment date: ");
            var enrollmentDate = Convert.ToDateTime(Console.ReadLine());
            var student = new Students()
            {
                Fullname = fullname,
                Email = email,
                Phone = phone,
                EnrollmentDate = DateOnly.FromDateTime(enrollmentDate)
            };
            await studentService.AddStudent(student);
            break;
        case "4":
            Console.Write("Enter id: ");
            var uStudentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter fullname: ");
            var uFullname = Console.ReadLine()!;
            Console.Write("Enter email: ");
            var uEmail = Console.ReadLine()!;
            Console.Write("Enter phone: ");
            var uPhone = Console.ReadLine()!;
            Console.Write("Enter enrollment date: ");
            var uEnrollmentDate = Convert.ToDateTime(Console.ReadLine());
            var uStudent = new Students()
            {
                Id = uStudentId,
                Fullname = uFullname,
                Email = uEmail,
                Phone = uPhone,
                EnrollmentDate = DateOnly.FromDateTime(uEnrollmentDate)
            };
            await studentService.UpdateStudent(uStudent);
            break;
        case "5":
            Console.Write("Enter id: ");
            var dStudentId = Convert.ToInt32(Console.ReadLine());
            await studentService.DeleteStudent(dStudentId);
            break;

        case "6":
            await courseService.GetAllCourse();
            break;

        case "7":
            Console.Write("Enter id: ");
            var course_id = Convert.ToInt32(Console.ReadLine());
            await courseService.GetCourse(course_id);
            break;

        case "8":
            Console.Write("Enter title: ");
            var title = Console.ReadLine()!;
            Console.Write("Enter description: ");
            var description = Console.ReadLine()!;
            Console.Write("Enter duration weeks: ");
            var durationWeeks = Convert.ToInt32(Console.ReadLine());
            var course = new Courses()
            {
                Title = title,
                Description = description,
                DurationWeeks = durationWeeks
            };
            await courseService.AddCourse(course);
            break;

        case "9":
            Console.Write("Enter id: ");
            var uCourseId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter title: ");
            var uTitle = Console.ReadLine()!;
            Console.Write("Enter description: ");
            var uDescription = Console.ReadLine()!;
            Console.Write("Enter duration weeks: ");
            var uDurationWeeks = Convert.ToInt32(Console.ReadLine());
            var uCourse = new Courses()
            {
                Id = uCourseId,
                Title = uTitle,
                Description = uDescription,
                DurationWeeks = uDurationWeeks
            };
            await courseService.UpdateCourse(uCourse);
            break;

        case "10":
            Console.Write("Enter id: ");
            var dCourseId = Convert.ToInt32(Console.ReadLine());
            await courseService.DeleteCourse(dCourseId);
            break;

        case "11":
            await mentorService.GetAllMentor();
            break;

        case "12":
            Console.Write("Enter id: ");
            var mentor_id = Convert.ToInt32(Console.ReadLine());
            await mentorService.GetMentor(mentor_id);
            break;

        case "13":
            Console.Write("Enter fullname: ");
            var mentorFullname = Console.ReadLine()!;
            Console.Write("Enter email: ");
            var mentorEmail = Console.ReadLine()!;
            Console.Write("Enter phone: ");
            var mentorPhone = Console.ReadLine()!;
            var mentor = new Mentors()
            {
                Fullname = mentorFullname,
                Email = mentorEmail,
                Phone = mentorPhone
            };
            await mentorService.AddMentor(mentor);
            break;

        case "14":
            Console.Write("Enter id: ");
            var uMentorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter fullname: ");
            var uMentorFullname = Console.ReadLine()!;
            Console.Write("Enter email: ");
            var uMentorEmail = Console.ReadLine()!;
            Console.Write("Enter phone: ");
            var uMentorPhone = Console.ReadLine()!;
            var uMentor = new Mentors()
            {
                Id = uMentorId,
                Fullname = uMentorFullname,
                Email = uMentorEmail,
                Phone = uMentorPhone
            };
            await mentorService.UpdateMentor(uMentor);
            break;

        case "15":
            Console.Write("Enter id: ");
            var dMentorId = Convert.ToInt32(Console.ReadLine());
            await mentorService.DeleteMentor(dMentorId);
            break;

        case "16":
            await groupService.GetAllGroup();
            break;

        case "17":
            Console.Write("Enter id: ");
            var group_id = Convert.ToInt32(Console.ReadLine());
            await groupService.GetGroup(group_id);
            break;

        case "18":
            Console.Write("Enter group name: ");
            var groupName = Console.ReadLine()!;
            Console.Write("Enter course id: ");
            var courseId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter mentor id: ");
            var mentorId = Convert.ToInt32(Console.ReadLine());
            var group = new Groups()
            {
                GroupName = groupName,
                CourseId = courseId,
                MentorId = mentorId
            };
            await groupService.AddGroup(group);
            break;

        case "19":
            Console.Write("Enter id: ");
            var uGroupId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter group name: ");
            var uGroupName = Console.ReadLine()!;
            Console.Write("Enter course id: ");
            var uCourseIdi = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter mentor id: ");
            var uMentorIdi = Convert.ToInt32(Console.ReadLine());
            var uGroup = new Groups()
            {
                Id = uGroupId,
                GroupName = uGroupName,
                CourseId = uCourseIdi,
                MentorId = uMentorIdi
            };
            await groupService.UpdateGroup(uGroup);
            break;

        case "20":
            Console.Write("Enter id: ");
            var dGroupId = Convert.ToInt32(Console.ReadLine());
            await groupService.DeleteGroup(dGroupId);
            break;

        case "21":
            await studentgroupService.GetAllStudentGroup();
            break;

        case "22":
            Console.Write("Enter id: ");
            var studentGroupId = Convert.ToInt32(Console.ReadLine());
            await studentgroupService.GetStudentGroup(studentGroupId);
            break;

        case "23":
            Console.Write("Enter student id: ");
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter group id: ");
            var groupId = Convert.ToInt32(Console.ReadLine());
            var status = Enum.Parse<StudentGroupsStatus>(Console.ReadLine()!, true);
            var studentGroup = new StudentGroups()
            {
                StudentId = studentId,
                GroupId = groupId,
                Status=status
            };
            await studentgroupService.AddStudentGroup(studentGroup);
            break;

        case "24":
            Console.Write("Enter id: ");
            var uStudentGroupId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student id: ");
            var uStudentIdi = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter group id: ");
            var uGroupIdi = Convert.ToInt32(Console.ReadLine());
            var statuss=Enum.Parse<StudentGroupsStatus>(Console.ReadLine()!,true);
            var uStudentGroup = new StudentGroups()
            {
                StudentGroupId = uStudentGroupId,
                StudentId = uStudentIdi,
                GroupId = uGroupIdi,
                Status=statuss
            };
            await studentgroupService.UpdateStudentGroup(uStudentGroup);
            break;

        case "25":
            Console.Write("Enter id: ");
            var dStudentGroupId = Convert.ToInt32(Console.ReadLine());
            await studentgroupService.DeleteStudentGroup(dStudentGroupId);
            break;

        case "0":
            Console.WriteLine("Exiting ...");
            return;
    }
}

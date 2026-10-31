using Infrastructure.Repository;
using Infrastructure.Data;
using Application.Services;
using Domain.Models;
using Domain.Enames;
using System.Data.Common;

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
    6 - GetStudentsWithGroups.
    7 - GetStudentsWithoutGroups.
    8 - GetDroppedOutStudents.
    9 - GetGraduatedStudents.

    Table Courses!
    10 - Show all courses.
    11 - Show course.
    12 - Add new course.
    13 - Update course.
    14 - Delete course.
    15 - GetStudentsPerCourse.
    16 - GetMostPopularCourse.
    17 - GetLeastPopularCourses.
    18 - GetTopThreeCourses.
    
    Table Mentors!
    19 - Show all mentors.
    20 - Show mentor.
    21 - Add new mentors.
    22 - Update mentors.
    23 - Delete mentors.
    24 - GetMentorWithMostStudents.
    25 - GetMentorsWithMultipleCourses.

    Table Groups!
    26 - Show all groups.
    27 - Show groups.
    28 - Add new groups.
    29 - Update groups.
    30 - Delete groups.
    31 - GetStudentsPerGroup.
    32 - GetEmptyGroups.

    Table StudentGroups!
    33 - Show all studentgroups.
    34 - Show studentgroups.
    35 - Add new studentgroups.
    36 - Update studentgroups.
    37 - Delete studentgroups.
    38 - GetCompletionRate.
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
            var resul = await studentService.GetStudentsWithoutGroups();
            foreach (var item in resul)
            {
                Console.WriteLine(item.Id+" "+item.Fullname);
            }
            break;

        case "7":
            var resuls = await studentService.GetStudentsWithoutGroups();
            foreach (var item in resuls)
            {
                Console.WriteLine(item.Id+" "+item.Fullname);
            }
            break;
        
        case "8":
            var result = await studentService.GetDroppedOutStudents();
            foreach (var item in result)
            {
                Console.WriteLine(item.Id+" "+item.Fullname);
            }
            break;

        case "9":
            var resultt = await studentService.GetGraduatedStudents();
            foreach (var item in resultt)
            {
                Console.WriteLine(item.Id+" "+item.Fullname);
            }
            break;
        case "10":
            await courseService.GetAllCourse();
            break;

        case "11":
            Console.Write("Enter id: ");
            var course_id = Convert.ToInt32(Console.ReadLine());
            await courseService.GetCourse(course_id);
            break;

        case "12":
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

        case "13":
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

        case "14":
            Console.Write("Enter id: ");
            var dCourseId = Convert.ToInt32(Console.ReadLine());
            await courseService.DeleteCourse(dCourseId);
            break;
            
        case "15":
            var r=await courseService.GetStudentsPerCourse();
            foreach (var item in r)
            {
                Console.WriteLine(item.Id+" "+item.Title);
            } 
            break;
        
        case "16":
            var re = await courseService.GetMostPopularCourse();
            Console.WriteLine(re.Id+" "+re.Title);
            break;
        
        case "17":
            var res = await courseService.GetLeastPopularCourses();
            foreach (var item in res)
            {
                Console.WriteLine(item.Id+" "+item.Title);
            }
            break;

        case "18":
            var ress=await courseService.GetTopThreeCourses();
            foreach (var item in ress)
            {
                Console.WriteLine(item.Id+" "+item.Title);
            }    

            break;

        case "19":
            await mentorService.GetAllMentor();
            break;

        case "20":
            Console.Write("Enter id: ");
            var mentor_id = Convert.ToInt32(Console.ReadLine());
            await mentorService.GetMentor(mentor_id);
            break;

        case "21":
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

        case "22":
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

        case "23":
            Console.Write("Enter id: ");
            var dMentorId = Convert.ToInt32(Console.ReadLine());
            await mentorService.DeleteMentor(dMentorId);
            break;

        case "24":
            var men=await mentorService.GetMentorWithMostStudents();
            Console.WriteLine(men.Id+" "+men.Fullname);
            break;

        case "25":
            var ment = await mentorService.GetMentorsWithMultipleCourses();
            foreach (var item in ment)
            {
                Console.WriteLine(item.Id+" "+item.Fullname);
            }
            break;

        case "26":
            await groupService.GetAllGroup();
            break;

        case "27":
            Console.Write("Enter id: ");
            var group_id = Convert.ToInt32(Console.ReadLine());
            await groupService.GetGroup(group_id);
            break;

        case "28":
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

        case "29":
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

        case "30":
            Console.Write("Enter id: ");
            var dGroupId = Convert.ToInt32(Console.ReadLine());
            await groupService.DeleteGroup(dGroupId);
            break;

        case "31":
            var mn = await groupService.GetStudentsPerGroup();
            foreach (var g in mn)
            {
                Console.WriteLine(g.Id+" "+g.GroupName);
            }
            break;

        case "32":
            var grou = await groupService.GetEmptyGroups();
            foreach (var g in grou)
            {
                Console.WriteLine(g.Id+" "+g.GroupName);
            }
            break;

        case "33":
            await studentgroupService.GetAllStudentGroup();
            break;

        case "34":
            Console.Write("Enter id: ");
            var studentGroupId = Convert.ToInt32(Console.ReadLine());
            await studentgroupService.GetStudentGroup(studentGroupId);
            break;

        case "35":
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

        case "36":
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

        case "37":
            Console.Write("Enter id: ");
            var dStudentGroupId = Convert.ToInt32(Console.ReadLine());
            await studentgroupService.DeleteStudentGroup(dStudentGroupId);
            break;

        case "38":
            var sg = await studentgroupService.GetCompletionRate();
            Console.WriteLine($"Completion Rate: {sg}%");
            break;

        case "0":
            Console.WriteLine("Exiting ...");
            return;
    }
}


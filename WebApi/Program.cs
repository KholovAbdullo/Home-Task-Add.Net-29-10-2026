using Application.interfaces;
using Application.Services;
using Domain.interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<Database>();

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICoursesRepository, CourseRepository>();

builder.Services.AddScoped<IGroupsService, GroupsService>();
builder.Services.AddScoped<IGroupsRepository, GroupsRepository>();

builder.Services.AddScoped<IMentorService, MentorService>();
builder.Services.AddScoped<IMentorRepository, MentorRepository>();

builder.Services.AddScoped<IStudentServices, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IStudentGroupsService, StudentGroupsService>();
builder.Services.AddScoped<IStudentGroupsRepository, StudentGroupRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseMiddleware<RequestLoggingMiddleware>();
app.Run();
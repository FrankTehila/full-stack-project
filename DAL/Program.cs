// See https://aka.ms/new-console-template for more information
using DAL.api;
using DAL.models;
using DAL.services;
using DAL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// הוספת שירותים
builder.Services.AddDbContext<dbClass>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IMeetingService, MeetingService>();
builder.Services.AddScoped<IRoomService, RoomService>();

var app = builder.Build();

// קוד לקונפיגורציה של האפליקציה
app.Run();


using BL.api;
using BL.Models;
using BL.services;
using DAL.api;
using DAL.models;
using DAL.services;
using DAL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// רישום השירותים
builder.Services.AddScoped<dbClass>(); // ודא שהשירות הזה קיים
builder.Services.AddScoped<IEmployeeService, EmployeeService>(); // רישום השירות
builder.Services.AddScoped<IEmployeeServiceBL, EmployeeServiceBL>(); // רישום השירות בל
builder.Services.AddScoped<IMeetingServiceBL, MeetingServiceBL>(); // רישום שירותים נוספים
builder.Services.AddScoped<IMeetingBL, MeetingBL>();
builder.Services.AddScoped<IEmployeeServiceBL, EmployeeServiceBL>();
builder.Services.AddScoped<IRoomServiceBL, RoomServiceBL>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<dbClass>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<TeamLeaderService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

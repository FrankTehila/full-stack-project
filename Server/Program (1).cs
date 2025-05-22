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

// ����� ��������
builder.Services.AddScoped<dbClass>(); // ��� ������� ��� ����
builder.Services.AddScoped<IEmployeeService, EmployeeService>(); // ����� ������
builder.Services.AddScoped<IEmployeeServiceBL, EmployeeServiceBL>(); // ����� ������ ��
builder.Services.AddScoped<IMeetingServiceBL, MeetingServiceBL>(); // ����� ������� ������
builder.Services.AddScoped<IMeetingBL, MeetingBL>();
builder.Services.AddScoped<IRoomServiceBL, RoomServiceBL>();
builder.Services.AddScoped<IRoomService, RoomService>();

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

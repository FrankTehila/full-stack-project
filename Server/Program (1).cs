
using BL.api;
using BL.services;
using BL.Models;
using Microsoft.Extensions.DependencyInjection;
using DAL.api;
using DAL.services;
using DAL.Services;
using DAL.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMeetingServiceBL, MeetingServiceBL>();
builder.Services.AddScoped<IMeetingBL, MeetingBL>();
//builder.Services.AddScoped<IEmployeeServiceBL, EmployeeServiceBL>();
builder.Services.AddScoped<IRoomServiceBL, RoomServiceBL>();
//builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<dbClass>();






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

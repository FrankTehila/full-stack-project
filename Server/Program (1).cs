using BL.api;
using BL.models;
using BL.services;
using DAL.api;
using DAL.models;
using DAL.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<dbClass>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeServiceBL, EmployeeServiceBL>();
builder.Services.AddScoped<IMeetingServiceBL, MeetingServiceBL>();
builder.Services.AddScoped<IMeetingBL, MeetingBL>();
builder.Services.AddScoped<MeetingService>();
builder.Services.AddScoped<IRoomServiceBL, RoomServiceBL>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<TeamLeaderService>();

// הגדרת CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder.WithOrigins("http://localhost:5173", "http://localhost:5174", "http://localhost:5036")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();בפיתוח בלבד
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();
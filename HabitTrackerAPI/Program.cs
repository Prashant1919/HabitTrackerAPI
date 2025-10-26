using HabitTrackerAPI.Data;
using HabitTrackerAPI.repo;
using HabitTrackerAPI.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//register   Repositories (Data access layer)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHabit,Habitrepo>();
builder.Services.AddScoped<IHabitLog, HabitLogrepository>();
// register Services (Business Logic Layer)
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHabitservice, HabitService>();
builder.Services.AddScoped<IHabitLogsService,Habitlogservice>();
// Add Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using School_Bus_Api.Data;
using School_Bus_Api.Repos.Bus_Repo;
using School_Bus_Api.Repos.Driver_Repo;
using School_Bus_Api.Repos.ForgetPassword_Repo;
using School_Bus_Api.Repos.Login_Repo;
using School_Bus_Api.Repos.Registration_Repo;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connect = builder.Configuration.GetConnectionString("schoolbusConnect");
builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(connect));

builder.Services.AddScoped<ISignUpRepo, SignUpRepo>();
builder.Services.AddScoped<ILoginRepo, LoginRepo>();
builder.Services.AddScoped<IForgetPasswordRepo, ForgetPasswordRepo>();
builder.Services.AddScoped<IDriverRepo, DriverRepo>();
builder.Services.AddScoped<IBusRepo, BusRepo>();

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

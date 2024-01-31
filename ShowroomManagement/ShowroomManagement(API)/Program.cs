using Microsoft.EntityFrameworkCore;
using ShowroomManagement_API_.Data;
using ShowroomManagement_API_.Models;
using ShowroomManagement_API_.Repositories;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------- API POLICY -------------- //
builder.Services.AddCors(x => x.AddPolicy(MyAllowSpecificOrigins,Policy => { 
                 Policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
}));

// -------------- APPLICATIONDBCONTEXT DEPENDENCY -------------- //
builder.Services.AddDbContext<ApplicationDbContext>(x => 
                                x.UseSqlServer(builder.Configuration.GetConnectionString("Default")
 ));

// -------------- MODELS DEPENDENCY -------------- //
builder.Services.AddScoped<IDepartment,DepartmentModel>();
builder.Services.AddScoped<IEmployee,EmployeeModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

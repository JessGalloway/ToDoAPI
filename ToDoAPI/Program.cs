//Step 2 Scaffold-DbContext in package manager console


//Step 3 add the using statments
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

// Questions for the instructor:
    //When does ToDo become API? the only thing named ToDoAPI is the project name everything else is ToDo.


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding Cors
builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(policy => 
    {
        policy.WithOrigins("OriginsPolicy", "http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
    });

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Step 4 addd the Db context service to initiate the Db connection 
builder.Services.AddDbContext<ToDoAPI.Models.ToDoContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoDB"));

});




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

app.UseCors();

app.Run();

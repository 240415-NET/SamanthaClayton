// This program.cs is way different than what we're used to seeing
// It runs almost as a script, from top to bottom, where we add services
// to our AppBuilder and thne we build the app.
// After the app has been built, we can toggle different options for it.
// All of this is done when we dotnet run our webAPI

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //Add Swagger

var app = builder.Build(); // Build the app

// Do some configuration 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(); // Run the app
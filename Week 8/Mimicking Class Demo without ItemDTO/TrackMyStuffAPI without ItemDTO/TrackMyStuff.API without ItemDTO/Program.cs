/*
This Program.cs file is different than what
we are used to seeing.  It runs almost as a
script (from top to bottom).  We add "services"
to our AppBuilder and then we build the app.
After the app is built, we can toggle different
options for it.  Adding the "services" to our
AppBuilder, building the app, & toggling
the options are all done when we run the
"dotnet run" command in our Web API
*/

using Microsoft.EntityFrameworkCore; // ALLOWS US TO ADD THE CONTEXT CLASS
using TrackMyStuff.API.Data;
using TrackMyStuff.API.Services;

// CREATE THE APP BUILDER
var builder = WebApplication.CreateBuilder(args);



// ADD SERVICES TO THE APP BUILDER
    /*
    This is where we'll add "services" to the
    container.  By default, AddControllers(),
    AddEndPointsApiExplorer(), & AddSwaggerGen()
    will be included in the Program.cs.

    Initially, those are loaded in that order,
    but we are going to move AddControllers() 
    to be the last thing added so that it is
    added AFTER all of our dependencies. NOTE:
    I tried having this where Jonathan put it (down
    below after the dependencies) and then also
    up here and it didn't seem to affect anything,
    so I'm going to leave it up here where it was
    originally.
    */

    // This is where the AddController() was originally.
    // Leaving it here since I didn't notice a difference vs.
    // moving it down after the depdencies.

builder.Services.AddControllers();
    
    // Auto-generated comment: Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //Add Swagger



// REGISTER THE DEPENDENCIES
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserStorage, UserStorage>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemStorage, ItemStorage>();







// ADD THE CONTEXT CLASS TO THE APP BUILDER
    /*
    This context class inherits from Entity
    Framework Core's DbContext
    */

string connectionString = File.ReadAllText(@"C:\Users\u41046\Revature Engineer Bootcamp\MimickingTrackMyStuffConnectionString.txt");
builder.Services.AddDbContext<TrackMyStuffContext>(options =>
    options.UseSqlServer(connectionString));



// ADD THE ADDCONTROLLERS() SERVICE TO THE BUILDER
// I tried this both ways (having it down here vs. having it
// up above where it was originally and it didn't seem to make
// any difference.  So I'm leaving it up there.
//builder.Services.AddControllers();




// BUILD THE APP



var app = builder.Build();


// CONFIGURATION

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

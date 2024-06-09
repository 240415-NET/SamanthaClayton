using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => c.UseDateOnlyTimeOnlyStringConverters());
builder.Services.AddDateOnlyTimeOnlyStringConverters();




builder.Services.AddScoped<IUserService, UserService>(); // This adds our UserService, that our UserController then asks for
builder.Services.AddScoped<IUserStorageEFRepo, UserStorageEFRepo>();// This adds our UserStorageEFRepo (data-access layer), that our UserService asks for. 
builder.Services.AddScoped<IActivityService, ActivityService>(); 
builder.Services.AddScoped<IActivityStorageEFRepo, ActivityStorageEFRepo>();

/*builder.Services.AddControllers().AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling = 
        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
*/
string connectionString = File.ReadAllText(@"../../../ActivityTrackerNoDTOWithUserIdInItem.txt");

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(connectionString));

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

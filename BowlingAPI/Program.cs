//import models used, database access, tools for handling JSON serialization
using BowlingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

//web application builder
var builder = WebApplication.CreateBuilder(args);

// services
//controller support so the API can handle HTTP requests
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

//connect to the database
builder.Services.AddDbContext<BowlingContext>(options =>
    //project uses a SQLite database
    options.UseSqlite("Data Source=Data/BowlingLeague.sqlite"));

//frontend can access this API
builder.Services.AddCors();

//Build the app
var app = builder.Build();

// middleware
//allows the React frontend to call the API
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//controller routes
app.MapControllers();

//Start the web app
app.Run();
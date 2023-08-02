using FoodSeedMySqlDatabase.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NewFoodDbContext>(opt =>
    opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:DevNewFoodDbMySQL")!));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
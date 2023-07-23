using DotNetServer.Context;
using DotNetServer.Model.Requests;
using DotNetServer.Repositories;
using DotNetServer.Services;
using DotNetServer.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FoodbContext>(opt =>
    opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:DevFoodbMySQL")!));

if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<FoodbContext>(opt =>
        opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:ProFoodbMySQL")!));

builder.Services.AddSingleton<IFoodRepository, FoodRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserContentRepository, UserContentRepository>();

builder.Services.AddSingleton<IFoodService, FoodService>();

builder.Services.AddScoped<IValidator<UserRequest>, UserRequestValidator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEnd",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("FrontEnd");

app.UseAuthorization();

app.MapControllers();

app.Run();
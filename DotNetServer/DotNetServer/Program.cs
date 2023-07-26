using DotNetServer.Core.Context;
using DotNetServer.Modules.FoodModule.Repositories;
using DotNetServer.Modules.FoodModule.Services;
using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Repositories;
using DotNetServer.Modules.UserContentModule.Services;
using DotNetServer.Modules.UserContentModule.Validations;
using DotNetServer.Modules.UserModule.Model.Requests;
using DotNetServer.Modules.UserModule.Repositories;
using DotNetServer.Modules.UserModule.Services;
using DotNetServer.Modules.UserModule.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FoodbContext>(opt =>
    opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:DevFoodbMySQL")!));

if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<FoodbContext>(opt =>
        opt.UseMySQL(builder.Configuration.GetValue<string>("ConnectionString:ProFoodbMySQL")!));

builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserContentRepository, UserContentRepository>();

builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserContentService, UserContentService>();

builder.Services.AddScoped<IValidator<UserRequest>, UserRequestValidator>();
builder.Services.AddScoped<IValidator<UserContentRequest>, UserContentRequestValidator>();
builder.Services.AddScoped<IValidator<MinimalUserRequest>, MinimalUserRequestValidation>();

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

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
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
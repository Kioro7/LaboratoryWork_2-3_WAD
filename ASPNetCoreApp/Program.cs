using ASPNetCoreApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole<int>>().AddRoles<IdentityRole<int>>().AddEntityFrameworkStores<GamingPlatform>().AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( builder => 
    { 
        builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod(); 
    });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<GamingPlatform>();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "GamingPlatformApp";
    options.LoginPath = "/";
    options.AccessDeniedPath = "/";
    options.LogoutPath = "/";
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    // Возвращать 401 при вызове недоступных методов для роли     
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var gamingContext = scope.ServiceProvider.GetRequiredService<GamingPlatform>();
    await GenresSeed.SeedAsync(gamingContext);
    await GamesSeed.SeedAsync(gamingContext);
    await IdentitySeed.CreateUserRoles(scope.ServiceProvider);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

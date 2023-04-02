using ASPNetCoreApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<GamingPlatform>().AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( 
        builder => {
        builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<GamingPlatform>();
builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var gamingContext = scope.ServiceProvider.GetRequiredService<GamingPlatform>();
    await GamingPlatformSeed.SeedAsync(gamingContext);
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

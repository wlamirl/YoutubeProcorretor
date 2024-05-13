using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;

using YoutubeApi.Youtube;
using YoutubeProcorretor.Components;
using YoutubeProcorretor.Context;
using YoutubeProcorretor.Services;
using YoutubeProcorretor.Services.Youtube;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

// var connectionString = builder.Configuration.GetConnectionString("Sqlite");
// builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connectionString));

var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(mySqlConnection,
                    ServerVersion.AutoDetect(mySqlConnection))); //,

builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IYoutubeService, YoutubeService>();

var app = builder.Build();

CreateDatabase(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}
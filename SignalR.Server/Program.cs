
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using SignalR.Server.Controller;
using SignalR.Server.Hubs;
using SignalR.Server.Services;
using SignalR.Services.Repositorys;
using Test.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DemoSQLiteConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddSignalR();
builder.Services.AddLogging();

builder.Services.AddScoped<Controller>();
builder.Services.AddScoped<ImRunningService>();
builder.Services.AddScoped<IMessageRepository, SqLiteMessageRepository>();
builder.WebHost.UseUrls("http://*:5100");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapHub<ChatHub>("/chat");
app.MapHub<IoHub>("/io");
app.MapHub<CornHub>("/corn");

app.Run();

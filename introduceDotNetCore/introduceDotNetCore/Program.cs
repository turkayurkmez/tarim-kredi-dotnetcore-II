
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var message = builder.Configuration.GetValue<string>("Message");

var app = builder.Build();
app.Logger.LogInformation($"config dosyasındaki mesaj: {message}");

app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

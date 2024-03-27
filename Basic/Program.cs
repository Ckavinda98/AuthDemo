using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Converting to MVC Structure 
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", config =>
    {
        config.Cookie.Name = "Police.Cookie";
        config.LoginPath = "/Home/Authenticate";
    });

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name : "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}");

app.Run();

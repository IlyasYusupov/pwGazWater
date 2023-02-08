using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using pwGazWater.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;


var users = Mongo.FindAll();
SingletonServise servise = new SingletonServise();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();
builder.Services.AddSignalR();



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<SingletonServise>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
var app = builder.Build();

app.UseAuthentication();   // добавление middleware аутентификации 
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/login", async context =>
    await SendHtmlAsync(context, "html/login.html"));

var user = servise.GetUser();
app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
{
    string email = user.Email;
    string password = user.Password;
});

app.MapGet("/", [Authorize] async (HttpContext context) =>
    await SendHtmlAsync(context, "html/index.html"));

app.MapGet("/admin", [Authorize(Roles = "admin")] async (HttpContext context) =>
    await SendHtmlAsync(context, "html/admin.html"));


app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/login");
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapHub<ChatHub>("/chat");
app.MapFallbackToPage("/_Host");

app.Run();

async Task SendHtmlAsync(HttpContext context, string path)
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync(path);
}
record class Person(string Email, string Password, Role Role);
record class Role(string Name);












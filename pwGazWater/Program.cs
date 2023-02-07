using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using pwGazWater.Data;
using Microsoft.AspNetCore.ResponseCompression;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

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
app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapPost("/login", (User loginModel) =>
{
    // находим пользователя  p => p.Email == loginModel.Email && p.Password == loginModel.Password
    User person = Mongo.Find(loginModel.Login);
    // если пользователь не найден, отправляем статусный код 401
    if (person is null) return Results.Unauthorized();

    var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, person.Login) };
    // создаем JWT-токен
    //var jwt = new JwtSecurityToken(
    //        issuer: AuthOptions.ISSUER,
    //        audience: AuthOptions.AUDIENCE,
    //        claims: claims,
    //        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
    //        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    //var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    // формируем ответ
    var response = new
    {
        //access_token = encodedJwt,
        username = person.Login
    };

    return Results.Json(response);
});



app.UseAuthentication();  
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapHub<ChatHub>("/chat");
app.MapFallbackToPage("/_Host");

app.Run();


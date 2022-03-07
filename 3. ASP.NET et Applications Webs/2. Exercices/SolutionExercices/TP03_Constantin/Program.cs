global using Bookstore.Models;
global using Bookstore.Controllers;
global using Bookstore.Models.ViewModel;
global using Bookstore.Controllers.Service;

var builder = WebApplication.CreateBuilder(args);
// Ajout de l'Authentification qui permettra d'utiliser une authentification de type cookies avec des options
builder.Services.AddAuthentication("AuthCookie").AddCookie("AuthCookie", options =>
{
    options.Cookie.Name = "AuthCookie"; // La nom du cookie
    options.LoginPath = "/Account/Login"; // Le chemin de redirection en cas de tentative d'accès à une page si on n'est pas logué
    options.AccessDeniedPath = "/Account/AccessDenied"; // Le chemin de la page d'erreur en cas de mauvais rôle
    options.ExpireTimeSpan = TimeSpan.FromDays(7); // Le delais d'expiration du cookie (ici 7 jours)
});


// Une fois l'authentification faite, on gère l'autorisation (pour gérer les droits potentiels des utilisateurs)
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Administrator")); // Ici, on fait une règle qui est d'être admin et seulement admin
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<DatabaseMock>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

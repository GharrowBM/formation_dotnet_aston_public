using C03_WebAPI.Datas;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FakeDb>();


// Configuration des CORS pour sécuriser et autoriser l'application par rapport à un navigateur web et une appli Front-End en Angular par exemple

builder.Services.AddCors(options => {

    // Option généraliste pour le développement
    options.AddPolicy("allConnections", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });

    // Option plus restrictive pour l'appli Front-End en Angular
    options.AddPolicy("angular", builder =>
    {
        builder.WithOrigins("https://angularAdress:angularPort").AllowAnyMethod().AllowAnyHeader();
    });
});

// Configuration de l'Authentification via JWT
builder.Services.AddAuthentication(options =>
{
    // Les options du shéma de l'authentification en elle même. Ici ne rien mettre n'aurait rien changé, mais c'est pour montrer qu'il est configurable
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // Les options du token a proprement parlé 
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Utilisation d'une clé cryptée pour la sécurité du token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"])), // Assignation de la valeur de la clé
        ValidateLifetime = true, // Vérification du temps d'expiration du token
        ValidateAudience = true, // Vérification de l'audience du token
        ValidAudience = builder.Configuration["JWT:ValidAudience"], // Audience validée pour ce token
        ValidateIssuer = true, // Vérification du donneur du token 
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"], // Donneur de token accepté pour ce token
        ClockSkew = TimeSpan.Zero // Décalage possible de l'expiration du token

    };
});

// On configure les règles d'autorisation de l'application

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin")); // Cette règle est cette fois-ci basée sur le rôle (qui est une claim de type Claim("Role", "Admin")
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(); // On active l'utilisation des CORS

app.UseAuthentication(); // On active l'utilisation de l'Authentification AVANT l'Autorisation
app.UseAuthorization();

app.MapControllers();

app.Run();

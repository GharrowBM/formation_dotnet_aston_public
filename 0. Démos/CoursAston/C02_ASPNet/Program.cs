using C02_ASPNet.Controllers.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IGetGuid, GetGuidService>();
//builder.Services.AddScoped<IGetGuid, GetGuidService>();
builder.Services.AddSingleton<IGetGuid, GetGuidService>();
builder.Services.AddSingleton<DabaseMock>();

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

app.UseAuthorization();

// On put spécifier une route alternative pour notre controller et notre action, comme ici on aura https://localhost:5001/clients

app.MapControllerRoute(name: "clients-list",
    pattern: "clients",
    defaults: new { controller = "Home", action = "GetMyClients" });

app.MapControllerRoute(name: "client-deletion",
    pattern: "client/del/{id}",
    defaults: new { controller = "Home", action = "RemoveClient" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

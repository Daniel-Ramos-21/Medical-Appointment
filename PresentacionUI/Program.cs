using AccesoDatos;
using LogicaNegocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
//Esta parte es para decirle al controlador que cada vez que se necesite usar
//el una clase de context  en este caso (medicalContext) que lo cree
//es decir crea la base de datos relacional al servidor SQL SERVER
//(Inyección de dependencias)
builder.Services.AddDbContext<MedicalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"))
);
builder.Services.AddHttpClient<CitaBLL>();
builder.Services.AddScoped<HistorialBLL>();
builder.Services.AddScoped<DoctoresBLL>();
builder.Services.AddScoped<ListaCitas>();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";

        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();
//Genaera la configucion de la aplicacion
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<MedicalContext>();
        // Esto aplicará las migraciones pendientes. 
        // Si la base de datos no existe, la crea. 
        // Si la tabla no existe la crea,
        // Si ya está al día, no hace nada.
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al migrar la base de datos.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiciosAdicionales.Models;
using ServiciosAdicionales.Repository;
using ServiciosAdicionales.Services;
using ServiciosAdicionales.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IPedidoDeServicioService, PedidoDeServiciosService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<ISitioService, SitioService>();
builder.Services.AddScoped<ITipoAdicionalService, TipoAdicionalService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Redirige a la página de Login
    options.AccessDeniedPath = "/Account/AccessDenied"; // Página de acceso denegado
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Tiempo de expiración de la cookie
    options.SlidingExpiration = true; // Extiende la sesión si el usuario sigue activo
});

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

// Activar autenticación y autorización
app.UseAuthentication(); // Necesario para ASP.NET Identity
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();

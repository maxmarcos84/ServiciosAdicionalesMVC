using Microsoft.EntityFrameworkCore;
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using AppEcommerce.Models;
using AppEcommerce.Repositories;
using AppEcommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.IOTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.Name = ".SessioneMVC.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Path = "/";
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});
builder.Services.AddDbContext<DbContesto>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("cefi")));
builder.Services.AddTransient<IProdottoRepository, ProdottoService>();
builder.Services.AddTransient<IAutenticaRepository, AutenticaService>();
builder.Services.AddTransient<IOrdineRepository, OrdineService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// gestione del task che esegue la lambda ogni volta che viene eseguite operazioni sulla sessione
app.Use(async (context, next) => //add adhoc "middleware"
{
    var lista_chiave = context.Session.Keys;
    if (!lista_chiave.Contains("carrello"))
        context.Session.SetString("carrello", JsonConvert.SerializeObject(new Carrello()));
     await next(context); //run next code
});

app.Run();

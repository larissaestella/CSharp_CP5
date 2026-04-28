using GameStore.Interfaces;
//using GameStore.Repositories;
using GameStore.Data;
using GameStore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// 🔐 1. AUTENTICAÇÃO
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AcessoNegado";
    });

// 🧱 2. DB CONTEXT
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// 🔌 3. INJEÇÃO DE DEPENDÊNCIA
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

// 🎮 MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🚨 4. CONFIGURAÇÃO DO PIPELINE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

// ⚠️ ORDEM IMPORTA
app.UseAuthentication();
app.UseAuthorization();

// 🗄️ 5. INICIALIZAÇÃO DO BANCO (UMA VEZ SÓ)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DatabaseInitializer.Initialize(context);
}

// 🌐 ROTAS
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
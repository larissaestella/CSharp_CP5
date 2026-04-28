using BCrypt.Net;
using GameStore.Interfaces;
using GameStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AuthController : Controller
{
    private readonly IUserRepository _repo;

    public AuthController(IUserRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = new User
        {
            Nome = model.Nome,
            Email = model.Email,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(model.Senha)
        };

        _repo.Add(user);
        return RedirectToAction("Login");
    }

    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var user = _repo.GetByEmail(model.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Senha, user.SenhaHash))
        {
            ModelState.AddModelError("", "Login inválido");
            return View(model);
        }

        var claims = new List<Claim>
        {
            // Alterado: Guardando o Nome real do usuário (para mostrar na tela)
            new Claim(ClaimTypes.Name, user.Nome),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role ?? "User") // Prevenção caso a role seja nula
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        return RedirectToAction("Index", "Home");
    }

    // Adicionado: Método para processar a saída (Logout)
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
using GameStore.Models;
using GameStore.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Services
{
    public class DatabaseInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Cria o banco automaticamente
            context.Database.Migrate();

            // Se já tiver jogos, não faz nada
            if (context.Games.Any())
                return;

            // 🔥 Games iniciais
            var games = new List<Game>
            {
                new Game
                {
                    Titulo = "God of War",
                    Descricao = "Acompanhe Kratos e Atreus em uma jornada épica e brutal pela mitologia nórdica.",
                    Preco = 199.90m,
                    UrlImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1593500/header.jpg"
                },
                new Game
                {
                    Titulo = "The Last of Us Part I",
                    Descricao = "Uma história emocionante e inesquecível de sobrevivência em um mundo devastado.",
                    Preco = 249.90m,
                    UrlImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1888930/header.jpg"
                },
                new Game
                {
                    Titulo = "Cyberpunk 2077",
                    Descricao = "Um RPG de ação e aventura em mundo aberto que se passa na megalópole de Night City.",
                    Preco = 199.90m,
                    UrlImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/header.jpg"
                },
                new Game
                {
                    Titulo = "EA SPORTS FC™ 25",
                    Descricao = "O Jogo de Todo Mundo. Viva a experiência mais autêntica do futebol mundial com ligas e times reais.",
                    Preco = 299.00m, 
                    UrlImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/2669320/header.jpg"
                },
                new Game
                {
                    Titulo = "Red Dead Redemption 2",
                    Descricao = "A épica história de Arthur Morgan no implacável coração dos Estados Unidos no fim da era do Velho Oeste.",
                    Preco = 299.90m,
                    UrlImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/1174180/header.jpg"
                },
                new Game
                {
                    Titulo = "The Witcher 3: Wild Hunt",
                    Descricao = "Jogue como o bruxo Geralt de Rívia em um universo de fantasia sombria cheio de escolhas difíceis.",
                    Preco = 139.90m,
                    UrlImagem = "https://cdn.cloudflare.steamstatic.com/steam/apps/292030/header.jpg"
                }
            };

            context.Games.AddRange(games);

            // 🔐 Admin automático
            if (!context.Users.Any(u => u.Email == "admin@gamestore.com"))
            {
                context.Users.Add(new User
                {
                    Nome = "Admin",
                    Email = "admin@gamestore.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Role = "Admin"
                });
            }

            context.SaveChanges();
        }
    }
}
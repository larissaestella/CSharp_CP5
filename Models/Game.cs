using System.ComponentModel.DataAnnotations;
namespace GameStore.Models;

public class Game
{
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; }

    public string Descricao { get; set; }

    [Required]
    public decimal Preco { get; set; }

    public string UrlImagem { get; set; }
}
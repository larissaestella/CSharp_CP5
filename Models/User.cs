using System.ComponentModel.DataAnnotations;
namespace GameStore.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string SenhaHash { get; set; }

    public string Role { get; set; } = "User";
}
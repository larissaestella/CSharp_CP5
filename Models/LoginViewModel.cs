using System.ComponentModel.DataAnnotations;
namespace GameStore.Models;

public class LoginViewModel
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }

    public string Nivel { get; set; } = "Operador";

}
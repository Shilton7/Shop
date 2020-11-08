using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório")]
    [MaxLength(30, ErrorMessage = "O campo deve conter entre 3 e 30 caracteres")]
    [MinLength(3, ErrorMessage = "O campo deve conter entre 3 e 30 caracteres")]
    public string Username { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório")]
    [MaxLength(30, ErrorMessage = "O campo deve conter entre 3 e 30 caracteres")]
    [MinLength(3, ErrorMessage = "O campo deve conter entre 3 e 30 caracteres")]
    public string Password { get; set; }

    public string Role { get; set; }

  }
}

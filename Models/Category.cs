using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
  public class Category
  {

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve conter entre 4 e 60 caracteres")]
    [MinLength(4, ErrorMessage = "Este campo deve conter entre 4 e 60 caracteres")]

    public string Title { get; set; }

  }

}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using myapi.Helpers;

namespace myapi.Entities
{
  [Table("users")]
  public class User
  {
    public int Id { get; set; }

    [Required, MaxLength(20)]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe ser una cadena de texto con una longitud entre 6 y 20.")]
    public string Name { get; set; }

    [Required, MaxLength(200)]
    [StringLength(16, MinimumLength = 8)]
    public string Password { get; set; }

    [Required, MaxLength(200), EmailAddress]
    public string Email { get; set; }

    [Required, MaxLength(50)]
    [StringLength(50, MinimumLength = 1)]
    public string Firstname { get; set; }

    [Required, MaxLength(50)]
    [StringLength(50, MinimumLength = 1)]
    public string Lastname { get; set; }

    [Required, MaxLength(6), Gender]
    public string Gender { get; set; }
  }

  // TODO: Crear validación de fortaleza de contraseña a nivel de modelo
  // La contraseña debe contener al menos 1 número, 1 letra minuscula,
  // 1 letra mayuscula, 1 simbolo
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using myapi.Helpers;

namespace myapi.Entities
{
  [Table("users")]
  public class User : IValidatableObject
  {
    public int Id { get; set; }

    [Required, MaxLength(20)]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe ser una cadena de texto con una longitud entre 6 y 20.")]
    public string Name { get; set; }

    [Required, MaxLength(200)]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "La contraseña debe tener de 8 a 16 caracteres.")]
    // TODO: crear un atributo que valide cuando la contraseña tenga espacios y 
    // mencione el error, que no debe llevar espacios.
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

    // Validación de la fortaleza de contraseña a nivel de modelo
    // La contraseña debe contener al menos 1 número, 1 letra minuscula,
    // 1 letra mayuscula, 1 simbolo, no debe contener espacios
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      // agregar la logica de las validaciones
      var strengh = PasswordStrengh();
      if (strengh < 3)
      {
        yield return new ValidationResult($"La contraseña es {(StrenghPassword)strengh}, agrega numeros, mayusculas, minusculas y simbolos", new string[] { nameof(Password) });
      }
    }

    private int PasswordStrengh()
    {
      var strengh = 0;
      if (Password.Any(c => char.IsDigit(c)))
        strengh++;

      if (Password.Any(c => char.IsUpper(c)))
        strengh++;

      if (Password.Any(c => char.IsLower(c)))
        strengh++;

      if (Password.Any(c => char.IsSymbol(c)))
        strengh++;
      return strengh;
    }
  }

  public enum StrenghPassword
  {
    VeryWeak = 1,
    Weak = 2,
    Strong = 3,
    VeryStrong = 4
  }
}
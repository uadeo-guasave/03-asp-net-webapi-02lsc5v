using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace myapi.Helpers
{
  public class WithoutSpaceAttribute : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var pwd = value.ToString();
      if (pwd.Any(c => char.IsWhiteSpace(c)))
      {
        return new ValidationResult("La contraseña no debe contener espacios");
      }

      return ValidationResult.Success;
    }
  }
}
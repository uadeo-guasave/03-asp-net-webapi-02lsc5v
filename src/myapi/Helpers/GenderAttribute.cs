using System.ComponentModel.DataAnnotations;

namespace myapi.Helpers
{
  public class GenderAttribute : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var gender = value.ToString().ToUpper();
      if (gender != "MALE" && gender != "FEMALE")
      {
        return new ValidationResult("El valor para género solo puede ser MALE o FEMALE.");
      }

      return ValidationResult.Success;
    }
  }
}
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class RegisterFormModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nazwa użytkownika nie może być puste")]
    public string? Name { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Pole email nie może być puste")]
    public string? Email { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Pole hasło nie może być puste")]
    public string? Password { get; set; }

    public string? PasswordRepeated { get; set; }
}
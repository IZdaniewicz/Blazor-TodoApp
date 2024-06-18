using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class LoginFormModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Pole email nie może być puste")]
    public string? Email { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Pole hasło nie może być puste")]
    public string? Password { get; set; }
}
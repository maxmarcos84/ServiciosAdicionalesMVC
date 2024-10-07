using System;
using System.ComponentModel.DataAnnotations;

namespace ServiciosAdicionales.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "El IGG es obligatorio")]
    [Display(Name = "IGG")]
    public string IGG { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Recordarme")]
    public bool RememberMe { get; set; }

}

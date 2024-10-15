using System;
using System.ComponentModel.DataAnnotations;
using ServiciosAdicionales.Models;

namespace ServiciosAdicionales.ViewModels;

public class RegistroViewModel
{
    [Required(ErrorMessage = "El IGG es obligatorio")]
    [Display(Name = "IGG")]
    public string IGG { get; set; }
    [Required(ErrorMessage = "El email es obligatorio")]
    public string Email { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirmar contraseña")]
    [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
    public string ConfirmPassword { get; set; }

    

}

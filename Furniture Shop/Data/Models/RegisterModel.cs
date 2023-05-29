using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Furniture_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Furniture_Shop.ViewModels.RegisterModel
{
    public class RegisterModel
    {
        [Display(Name = "Username")]
        [StringLength(30)]
        [MinLength(5, ErrorMessage = "At least 5 symbols")]
        [Required(ErrorMessage = "At least 5 symbols")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [StringLength(30)]
        [MinLength(8, ErrorMessage = "At least 8 symbols")]
        [Required(ErrorMessage = "At least 8 symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Repeat password")]
        [StringLength(30)]
        [MinLength(8, ErrorMessage = "At least 8 symbols")]
        [Required(ErrorMessage = "At least 8 symbols")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and repeat password must be the same")]
        public string RepeatPassword { get; set; }

        [Display(Name = "Remember Me")] public bool RememberMe { get; set; }


        public string ReturnUrl { get; set; }
    }
}
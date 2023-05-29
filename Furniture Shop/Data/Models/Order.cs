using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Furniture_Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "First name")]
        [StringLength(30)]
        [MinLength(5, ErrorMessage = "At least 5 symbols")]
        [Required(ErrorMessage ="At least 5 symbols")]
        public string Name { get; set; }
        [Display(Name = "Last name")]
        [StringLength(30)]
        [MinLength(5, ErrorMessage = "At least 5 symbols")]
        [Required(ErrorMessage = "At least 5 symbols")]
        public string Surname { get; set; }
        [Display(Name = "City, street, house number")]
        [StringLength(60)]
        [MinLength(15, ErrorMessage = "At least 15 symbols")]
        [Required(ErrorMessage = "At least 15 symbols")]
        public string Address { get; set; }
        [Display(Name = "Phone number (with country code)")]
        [StringLength(20)]
        [MinLength(10, ErrorMessage = "At least 10 symbols")]
        [Required(ErrorMessage = "At least 10 symbols")]
        public string Phone { get; set; }
        [Display(Name = "E-mail")]
        [StringLength(60)]
        [MinLength(15, ErrorMessage = "At least 15 symbols")]
        [Required(ErrorMessage = "At least 15 symbols")]
        public string Email { get; set; }
        [BindNever]
        public DateTime OrderTime { get; set; }
        [BindNever]
        public List<OrderDetail> OrgerDetails { get; set; }
    }
}
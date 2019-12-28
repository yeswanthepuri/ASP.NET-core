using EmployManagment.core.Utlities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployManagment.core.ViewModel
{
    public class RegisterViewmodel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsExistingEmail", controller: "Account")]
        [ValidEmailDomain(allowedeDomain: "gmail.com",ErrorMessage ="Email Domain Must be Gmail.com only.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and Confirm Passowrd Didn't match.")]
        public string ConfirmPassword { get; set; }
    }
}

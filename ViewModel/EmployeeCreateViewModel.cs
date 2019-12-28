using EmployManagment.core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployManagment.core.ViewModel
{
    public class EmployeeCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string Fname { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Department")]
        public Dept? Department { get; set; }
        public IFormFile Photo { get; set; }
    }
}

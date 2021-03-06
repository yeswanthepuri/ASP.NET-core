﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployManagment.core.Models
{
    public class Employee
    {
        public Guid ID { get; set; }
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
        public string PhotoPath { get; set; }
    }
}

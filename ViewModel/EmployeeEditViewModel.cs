using EmployManagment.core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployManagment.core.ViewModel
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public Guid ID { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}

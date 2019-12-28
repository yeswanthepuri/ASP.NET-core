using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployManagment.core.ViewModel
{
    public class EditRoleViewModel
    {
        public string ID { get; set; }
        [Required(ErrorMessage = "Role Name is Required  ")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; } = new List<string>();
    }
}

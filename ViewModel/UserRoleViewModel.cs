using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployManagment.core.ViewModel
{
    public class UserRoleViewModel
    {
        public string UserID { get; set; }
        //Insturd of using this we use View Bag to Hold this value
        //public string RoleID { get; set; }
        public string UserName { get; set; }
        public bool IsSelcted { get; set; }
    }
}

using EmployManagment.core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployManagment.core.Models
{
   public interface IEmployeeRepository
    {
        HomeDetailsViewodel getEmployeebyID(Guid guid);
        List<Employee> getEmployees();
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employeeChanges);
        Employee DeleteEmployee(Guid employeeID);


    }
}

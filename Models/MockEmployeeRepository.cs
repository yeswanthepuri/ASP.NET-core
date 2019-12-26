using EmployManagment.core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployManagment.core.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employList;
        public MockEmployeeRepository()
        {
            _employList = new List<Employee>()
            {
                new Employee(){ID=Guid.NewGuid(),Fname="Krithvika",Lname="Epuri",Email="epuri.yeshu@gmail.com",Department=Dept.CEO},
                new Employee(){ID=Guid.NewGuid(),Fname="Yeswanth",Lname="Epuri",Email="epuri.yeswanth@us.gt.com",Department=Dept.Developer},
                new Employee(){ID=Guid.NewGuid(),Fname="Gayatri",Lname="Epuri",Email="epuri.gayatri@gmail.com",Department=Dept.Director}

            };
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.ID = Guid.NewGuid();
            _employList.Add(employee);
            return employee;
        }

        public Employee DeleteEmployee(Guid employeeID)
        {
            var getempbyID = getEmployeebyID(employeeID).Employee;
            _employList.Remove(getempbyID);
            return getempbyID;
        }

        public HomeDetailsViewodel getEmployeebyID(Guid guid)
        {
            HomeDetailsViewodel homeDetailsViewodel = new HomeDetailsViewodel();
            homeDetailsViewodel.Employee = _employList.FirstOrDefault(x => x.ID == guid);
            homeDetailsViewodel.title = string.Format($"Welcome {homeDetailsViewodel.Employee.Fname} we are glad to serve you");
            return homeDetailsViewodel;
        }

        public List<Employee> getEmployees()
        {
            return _employList.ToList();
        }

        public Employee UpdateEmployee(Employee employeeChanges)
        {
            var getempbyID = getEmployeebyID(employeeChanges.ID).Employee;
            getempbyID.Fname = employeeChanges.Fname;
            getempbyID.Lname = employeeChanges.Lname;
            getempbyID.Department = employeeChanges.Department;
            getempbyID.Email = employeeChanges.Email;
            return getempbyID;
        }
    }
}

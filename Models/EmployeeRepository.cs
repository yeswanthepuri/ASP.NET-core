using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployManagment.core.DataContext;
using EmployManagment.core.ViewModel;

namespace EmployManagment.core.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            appDbContext.Employees.Add(employee);
            appDbContext.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(Guid employeeID)
        {
            var employbyID = getEmployeebyID(employeeID).Employee;
            appDbContext.Employees.Remove(employbyID);
            appDbContext.SaveChanges();
            return employbyID;
        }

        public HomeDetailsViewodel getEmployeebyID(Guid guid)
        {
            var employee= appDbContext.Employees.Find(guid);
            HomeDetailsViewodel homeDetailsViewodel = new HomeDetailsViewodel() {Employee = employee };
            return homeDetailsViewodel;
        }

        public List<Employee> getEmployees()
        {
           return appDbContext.Employees.ToList();
        }

        public Employee UpdateEmployee(Employee employeeChanges)
        {
           var employee = appDbContext.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return employeeChanges;
        }
    }
}

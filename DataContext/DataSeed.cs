using EmployManagment.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployManagment.core.DataContext
{
    public static class DataSeed
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Fname="Krithvika",
                    Lname="Epuri",
                    Department= Dept.CEO,
                    Email="epuri.krithvika@gmail.com"
                }
                );
        }
    }
}

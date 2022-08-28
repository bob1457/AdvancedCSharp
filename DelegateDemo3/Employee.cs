using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo3
{
    internal class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public Char Gender { get; set; }
        public bool IsManager { get; set; }


        public static List<Employee> FilterEmployees(List<Employee> employees, Predicate<Employee> predicte)
        {
            List<Employee> employeeListFiltered = new List<Employee>();

            foreach (var employee in employees)
            {
                if (predicte(employee))
                {
                    employeeListFiltered.Add(employee);
                }
            }

            return employeeListFiltered;
        }

    }
}

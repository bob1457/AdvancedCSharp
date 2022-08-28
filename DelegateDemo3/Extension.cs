using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo3
{
    internal static class Extension
    {
        public static List<Employee> FilterEmployees(this List<Employee> employees, Predicate<Employee> predicte) // extension method to the class Employee (first parameter), the second parameter is required when the method is called
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

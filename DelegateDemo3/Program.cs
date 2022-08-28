// See https://aka.ms/new-console-template for more information
using DelegateDemo3;
using System.Collections.Generic;

Console.WriteLine("Generic Delegate Demo");

//******************* Func ******************************

MathOperation math = new();

//Func<int, int, int> calc = math.Sum;
//or
//Func<int, int, int> calc = delegate (int a, int b) { return a + b; };
// or
Func<int, int, int> calc = (a, b) => a + b;


float d = 2.5f, e = 5.27f;

int f = 4;

Func<float, float, int, float> calc2 = (arg1, arg2, arg3) => (arg1 + arg2) * arg3;

float result2 = calc2(d, e, f);

int result = calc(1, 2);

//Console.WriteLine($"Result: {result2}");

//******************* Action ******************************

Action<int, string, string, decimal> displayEmpRecords = (arg1, arg2, arg3, arg4) => Console.WriteLine($"Id: {arg1}{Environment.NewLine}First Name: {arg2}{Environment.NewLine}Last Name: {arg3}{Environment.NewLine}Salary: {arg4}");

Action<int, string, string, decimal, Char, bool> displayEmpDetaails = (arg1, arg2, arg3, arg4, arg5, arg6) => Console.WriteLine($"Id: {arg1}{Environment.NewLine}First Name: {arg2}{Environment.NewLine}Last Name: {arg3}{Environment.NewLine}Salary: {arg4}{Environment.NewLine}Gener: {arg5}{Environment.NewLine}Manager: {arg6}");

// Note: The Aciton above, like Func<>, can take up to 17 parameters.

//displayEmpRecords(1, "Bob", "Yuan", 85000);

//******************* Predicate ******************************

List<Employee> employees = new List<Employee>();

employees.Add(new Employee
{
    Id = 1,
    FirstName = "Bob",
    LastName = "Yuan",
    AnnualSalary = 850000,
    Gender = 'm',
    IsManager = true
});
employees.Add(new Employee
{
    Id = 2,
    FirstName = "Vitor",
    LastName = "Yuan",
    AnnualSalary = 550000,
    Gender = 'm',
    IsManager = false
});
employees.Add(new Employee
{
    Id = 3,
    FirstName = "Edward",
    LastName = "Yuan",
    AnnualSalary = 550000,
    Gender = 'm',
    IsManager = false
});
employees.Add(new Employee
{
    Id = 4,
    FirstName = "Sophia",
    LastName = "Yuan",
    AnnualSalary = 350000,
    Gender = 'f',
    IsManager = false
});

//List<Employee> employeesFiltered = Employee.FilterEmployees(employees, e => e.AnnualSalary < 500000);
// or
//List<Employee> employeesFiltered = employees.FilterEmployees(e => e.Gender == 'm'); // using extension method
// or
List<Employee> employeesFiltered = employees.Where(e => e.Gender == 'm').ToList(); // using linq



foreach (var employee in employeesFiltered)
{
    displayEmpDetaails(employee.Id, employee.FirstName, employee.LastName, employee.AnnualSalary, employee.Gender, employee.IsManager);
    Console.WriteLine();

}

Console.ReadKey();

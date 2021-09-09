using Microsoft.EntityFrameworkCore;
using MoreOnEFApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFRelationApplication
{
    class Program
    {
        CompanyContext companyContext;

        public Program()
        {
            companyContext = new CompanyContext();
        }
        public void AddDepartment()
        {
            Department department1 = new Department { Name = "HR" };
            companyContext.Departments.Add(department1);
            Department department2 = new Department { Name = "Ops" };
            companyContext.Departments.Add(department2);
            Console.WriteLine("Department created");
            companyContext.SaveChanges();
        }

        public void AddEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Add Employee");
            Console.WriteLine("Enter the Employee Name");
            employee.Name = Console.ReadLine();
            Console.WriteLine("Enter the Employee Age");
            try
            {
                employee.Age = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter Age in number format");
                employee.Age = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Availabe Departments");
            foreach (var item in companyContext.Departments)
            {
                Console.WriteLine("Department ID :" + item.Number);
                Console.WriteLine("Department Name :" + item.Name);
            }
            Console.WriteLine("Enter the Department ID");
            try
            {
                employee.DepartmentNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter Department Number in number format");
                employee.DepartmentNumber = Convert.ToInt32(Console.ReadLine());
            }
            companyContext.Employees.Add(employee);
            companyContext.SaveChanges();
            Console.WriteLine("Employee Added");
        }
        public void PrintEmployeesDepartmentWise()
        {
            foreach (var item in companyContext.Departments.Include(e => e.Employees))
            {
                Console.WriteLine("Department Number " + item.Number);
                Console.WriteLine("Departmeny Name " + item.Name);
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine("---------------Employee ID " + emp.EmployeeId);
                    Console.WriteLine("----------------Employee Name " + emp.Name);
                    Console.WriteLine("-----------------Employee Age " + emp.Age);
                }
            }
             
        }
        public void PrintEmployeesInDepartment()
        {
            Console.WriteLine("Please enter the department ID");
            int id = Convert.ToInt32(Console.ReadLine());
            List<Employee> employees = companyContext.Employees.Where(e => e.DepartmentNumber == id).ToList();
            foreach (var item in employees)
            {
                Console.WriteLine("Department Number " + item.DepartmentNumber);
                Console.WriteLine("--------Employee Id " + item.EmployeeId);
                Console.WriteLine("--------Employee Name " + item.Name);
                Console.WriteLine("--------Employee Age " + item.Age);
            }
        }
        void MoreLinq()
        {

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.AddDepartment();
            program.PrintEmployeesInDepartment();
            //program.AddEmployee();
            //program.PrintEmployeesDepartmentWise();
            Console.ReadKey();
        }
    }
}

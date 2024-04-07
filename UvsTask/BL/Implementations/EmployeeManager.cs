using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace BL.Implementations
{
    /// <summary>
    /// daryciau visur su dependency injection, bet tai tiesiog console application,
    /// taip pat prideciau loggeri, jei tai butu rimtas projektas(bet manau kad siam projektui uztektu ir isvedima i console, nes ne eis i productiona)
    /// </summary>
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepositoryDAL employeeDAL;

        public EmployeeManager() 
        {
            employeeDAL = new EmployeeRepositoryDAL();
        }

        public async Task<Employee?> GetEmployeeAsync(string employeeIdData)
        {
            Employee? employee = null;

            if (!int.TryParse(employeeIdData, out int employeeId))
            {
                Console.WriteLine("Invalid employee ID. Please enter a valid number");
                return employee;
            }

            try
            {
                employee = await employeeDAL.GetEmployeeAsync(employeeId);

                if (employee != null)
                {
                    Console.WriteLine(
                        $"ID: {employee.employeeid}, Name: {employee.employeename}, Salary: {employee.employeesalary}");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while processing your request. Please try again later");
                // logger.LogError(e, "Error when trying to add an employee.");
            }

            return employee;
        }

        public async Task SetEmployeeAsync(string employeeIdStr, string employeeSalaryStr, string employeeName)
        {

            if (!int.TryParse(employeeIdStr, out int employeeId))
            {
                Console.WriteLine("Invalid employee ID. Please enter a valid number");
                return;
            }

            if (!int.TryParse(employeeSalaryStr, out int employeeSalary))
            {
                Console.WriteLine("Invalid employee salary. Please enter a valid number");
                return;
            }

            var employee = new Employee
            {
                employeeid = employeeId,
                employeename = employeeName,
                employeesalary = employeeSalary
            };

            try
            {
                var response = await employeeDAL.SetEmployeeAsync(employee);

                Console.WriteLine(response
                    ? $"Employee {employee.employeename} added"
                    : "Employee was not added");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while processing your request. Please try again later");
                // logger.LogError(e, "Error when trying to set an employee.");
            }
        }
    }
}

using System;
using System.Runtime.InteropServices.ComTypes;
using BL.Implementations;
using BL.Interfaces;

namespace Employee
{
    /// <summary>
    /// Tikiuosi kad viska supratau teisingai, bet jei kazka ne taip supratau, tikrai galeciau pataisyt
    /// </summary>
    public class Program
    {
        private static readonly IEmployeeManager EmployeeManager = new EmployeeManager();
        private static readonly IConverter Converter = new Converter();

        static async Task Main(string[] args)
        {
            if (args.Length > 0)
            {
                var arguments = Converter.ConvertStringArrayToDictionary(args);
                switch (args[0].ToLower())
                {
                    case "set-employee":
                        if (arguments.TryGetValue("--employeeId", out var employeeIdStr) &&
                            arguments.TryGetValue("--employeeName", out var employeeName) &&
                            arguments.TryGetValue("--employeeSalary", out var employeeSalaryStr))
                        {
                            await EmployeeManager.SetEmployeeAsync(employeeIdStr, employeeSalaryStr, employeeName);
                        }
                        else
                        {
                            Console.WriteLine("To set employee you need write a three parameters: --employeeId, --employeeName, --employeeSalary");
                        }
                        break;
                    case "get-employee":
                        if (arguments.TryGetValue("--employeeId", out string? employeeIdData))
                        {
                            await EmployeeManager.GetEmployeeAsync(employeeIdData);
                        }
                        else Console.WriteLine("--employeeId parameter is not founded");
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }

            // Console.ReadKey();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Interfaces
{
    public interface IEmployeeManager
    {
        Task<Employee?> GetEmployeeAsync(string employeeIdData);

        Task SetEmployeeAsync(string employeeIdStr, string employeeSalaryStr, string employeeName);
    }
}

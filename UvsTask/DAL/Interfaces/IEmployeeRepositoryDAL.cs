﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IEmployeeRepositoryDAL
    {
        Task<Employee?> GetEmployeeAsync(int id);

        Task<bool> SetEmployeeAsync(Employee employee);
    }
}

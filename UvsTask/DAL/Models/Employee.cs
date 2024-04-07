using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    /// <summary>
    /// Padariau be camelcase, nes kiek maciau is scriptu pati duombaze buvo taip padaryta,
    /// gal ne ant tiek gerai zinau visas postgre taisykles, tai padariau taip kad viskas tikrai veiktu
    /// </summary>
    public class Employee
    {
        public int employeeid { get; set; }
        public string employeename { get; set; }
        public int employeesalary { get; set; }

    }
}

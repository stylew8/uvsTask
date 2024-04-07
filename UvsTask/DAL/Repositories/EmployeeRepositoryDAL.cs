using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    /// <summary>
    /// daryciau ir sitoje vietoj su dependency injection, bet tai tiesiog console application,
    /// tai tektu daugiau  kodo rasyt tam, tai pagalvojau kad gal geriau palikt taip kaip yra dabartiniam projekte
    ///
    /// Taip pat jei butu daugiau modeliu, padaryciau tam BaseRepository(abstract), ir jau Generic metodus
    /// </summary>
    public class EmployeeRepositoryDAL : IEmployeeRepositoryDAL
    {
        private readonly AppDbContext _context;

        public EmployeeRepositoryDAL()
        {
            _context = new AppDbContextFactory().CreateDbContext(new string[0]);
        }

        public async Task<Employee?> GetEmployeeAsync(int id)
        {
            return await _context.employees
                .FirstOrDefaultAsync(e => e.employeeid == id);
        }

        public async Task<bool> SetEmployeeAsync(Employee employee)
        {
            await _context.employees.AddAsync(employee);

            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}

using EmployeeTemperatureLog.Models;
using EmployeeTemperatureLog.Models.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Data.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpTempContext _context;
        public EmployeeRepository(EmpTempContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddEmployee(Employee NewEmployee)
        {
            NewEmployee.DateCreated = DateTime.Now;
            NewEmployee.LastUpdateDate = DateTime.Now;
            _context.Employees.Add(NewEmployee);
            await _context.SaveChangesAsync();
            return NewEmployee.EmployeeNumber;
        }

        public async Task<PaginatedList<Employee>> GetAllEmployees(int PageIndex, int PageSize)
        {
            var source = _context.Employees;
            var count = await source.CountAsync();
            var items = await source.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            var output = new PaginatedList<Employee>()
            {
                PageIndex = PageIndex,
                TotalRecords = count,
                Records = items
            };
            return output;
          
            
        }

        public async Task<Employee> GetEmployee(Guid EmployeeNumber)
        {
            if(_context.Employees.Any(Employee=>Employee.EmployeeNumber==EmployeeNumber))
            {
                return await _context.Employees.SingleOrDefaultAsync(Employee => Employee.EmployeeNumber == EmployeeNumber);
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByFirstName(string FirstName)
        {
            return await _context.Employees.Where(employee => employee.FirstName.ToLower() == FirstName.ToLower()).ToListAsync();

        }

        public async Task<IEnumerable<Employee>> GetEmployeeByLastName(string LastName)
        {
            return await _context.Employees.Where(employee => employee.LastName.ToLower() == LastName.ToLower()).ToListAsync();
        }

        public async Task<Guid> UpdateEmployee(Employee UpdatedEmployee)
        {
            if (_context.Employees.Any(Employee => Employee.EmployeeNumber == UpdatedEmployee.EmployeeNumber))
            {
                var oldRecord= await _context.Employees.SingleOrDefaultAsync(Employee => Employee.EmployeeNumber == UpdatedEmployee.EmployeeNumber);
                oldRecord.FirstName = UpdatedEmployee.FirstName;
                oldRecord.LastName = UpdatedEmployee.LastName;
                oldRecord.LastUpdateDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return UpdatedEmployee.EmployeeNumber;

            }
            return Guid.Empty;
        }
    }
}

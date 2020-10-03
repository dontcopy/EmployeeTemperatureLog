using EmployeeTemperatureLog.Models;
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
        public void AddEmployee(Employee NewEmployee)
        {
            NewEmployee.DateCreated = DateTime.Now;
            NewEmployee.LastUpdateDate = DateTime.Now;
            _context.Employees.Add(NewEmployee);
            _context.SaveChanges();
        }

        public Task<IEnumerable<Employee>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetEmployee(Guid EmployeeNumber)
        {
            if(!_context.Employees.Any(Employee=>Employee.EmployeeNumber==EmployeeNumber))
            {
                return await _context.Employees.SingleOrDefaultAsync(Employee => Employee.EmployeeNumber == EmployeeNumber);
            }
            return null;
        }

        public void UpdateEmployee(Employee UpdatedEmployee)
        {
            throw new NotImplementedException();
        }
    }
}

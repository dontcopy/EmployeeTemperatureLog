using EmployeeTemperatureLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Data.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(Guid EmployeeNumber);
        Task<IEnumerable<Employee>> GetAllEmployees();

        void AddEmployee(Employee NewEmployee);
        void UpdateEmployee(Employee UpdatedEmployee);
    }
}

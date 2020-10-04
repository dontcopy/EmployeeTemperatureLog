using EmployeeTemperatureLog.Models;
using EmployeeTemperatureLog.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Data.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(Guid EmployeeNumber);
        Task<IEnumerable<Employee>> GetEmployeeByFirstName(string FirstName);
        Task<IEnumerable<Employee>> GetEmployeeByLastName(string LastName);

        Task<PaginatedList<Employee>> GetAllEmployees(int PageIndex, int PageSize);

        Task<Guid> AddEmployee(Employee NewEmployee);
        Task<Guid> UpdateEmployee(Employee UpdatedEmployee);
    }
}

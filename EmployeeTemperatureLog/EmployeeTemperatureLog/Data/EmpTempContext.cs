using EmployeeTemperatureLog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Data
{
    public class EmpTempContext:DbContext
    {
        public EmpTempContext(DbContextOptions<EmpTempContext> options):base(options)
        { 
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TemperatureRecord> TemperatureRecords { get; set; }
    }
}

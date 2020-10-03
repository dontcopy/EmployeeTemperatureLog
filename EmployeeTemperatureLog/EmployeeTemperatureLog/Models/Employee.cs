using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastNumber { get; set; }
        public IEnumerable<TemperatureRecord> TemperatureRecords { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}

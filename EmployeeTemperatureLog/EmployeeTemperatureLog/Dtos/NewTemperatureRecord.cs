using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Dtos
{
    public class NewTemperatureRecord
    {
        [Required]
        public double Temperature { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
    }
}

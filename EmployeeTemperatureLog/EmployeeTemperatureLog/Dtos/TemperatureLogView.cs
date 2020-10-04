using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Dtos
{
    public class TemperatureLogView
    {
        public double Temperature { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime RecordDate { get; set; }

        public string FullName { get; set; }
    }
}

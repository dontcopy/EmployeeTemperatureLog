using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Models
{
    public class TemperatureRecord
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime  RecordDate { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}

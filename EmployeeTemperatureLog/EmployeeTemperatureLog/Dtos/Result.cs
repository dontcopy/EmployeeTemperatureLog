using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Dtos
{
    public class Result<T>
    {
        public String Message { get; set; }
        public T Data { get; set; }
    }
}

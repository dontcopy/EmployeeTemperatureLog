using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Models.Utilities
{
    public class PaginatedList<T> 
    {
        public int PageIndex { get; set; }
        public int TotalRecords { get; set; }

        public IEnumerable<T> Records { get; set; }
    }
}

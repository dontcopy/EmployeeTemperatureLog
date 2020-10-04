using EmployeeTemperatureLog.Models;
using EmployeeTemperatureLog.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Data.TemperatureLogRepository
{
    public interface ITemperatureLogRepository
    {
        Task<PaginatedList<TemperatureRecord>> GetTemperatureLogByDateRange(int PageIndex, int PageSize,DateTime StartDate,DateTime EndDate);
        Task<PaginatedList<TemperatureRecord>> GetTemperatureLogByTemperatureRange(int PageIndex, int PageSize, double StartTemp, double EndTemp);

        Task<PaginatedList<TemperatureRecord>> GetTemperatureLogByEmployeeId(int PageIndex, int PageSize, Guid EmployeeId);
        Task<bool> AddTemperatureLog(TemperatureRecord temperatureRecord);
    }
}

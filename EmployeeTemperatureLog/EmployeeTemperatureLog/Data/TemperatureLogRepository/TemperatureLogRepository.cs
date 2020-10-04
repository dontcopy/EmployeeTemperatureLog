using EmployeeTemperatureLog.Models;
using EmployeeTemperatureLog.Models.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Data.TemperatureLogRepository
{
    public class TemperatureLogRepository:ITemperatureLogRepository
    {
        private readonly EmpTempContext _context;
        public TemperatureLogRepository(EmpTempContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<TemperatureRecord>> GetTemperatureLogByDateRange(int PageIndex, int PageSize, DateTime StartDate, DateTime EndDate)
        {
            var source = _context.TemperatureRecords;
            var count = await source.CountAsync(log => (log.RecordDate >= StartDate) && (log.RecordDate <= EndDate));
            var items = await source
                .Include(emp => emp.Employee)
                .Where(log => (log.RecordDate >= StartDate) && (log.RecordDate <= EndDate))
                .Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            var output = new PaginatedList<TemperatureRecord>()
            {
                PageIndex = PageIndex,
                TotalRecords = count,
                Records = items
            };
            return output;
        }

        public async Task<PaginatedList<TemperatureRecord>> GetTemperatureLogByTemperatureRange(int PageIndex, int PageSize, double StartTemp, double EndTemp)
        {
            var source = _context.TemperatureRecords;
            var count = await source.CountAsync(log => (log.Temperature >= StartTemp) && (log.Temperature <= EndTemp));
            var items = await source
                .Include(emp=>emp.Employee)
                .Where(log => (log.Temperature >= StartTemp) && (log.Temperature <= EndTemp))
                .Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            var output = new PaginatedList<TemperatureRecord>()
            {
                PageIndex = PageIndex,
                TotalRecords = count,
                Records = items
            };
            return output;
        }

        public async Task<bool> AddTemperatureLog(TemperatureRecord temperatureRecord)
        {
            if(_context.Employees.Any(Employee=>Employee.EmployeeNumber== temperatureRecord.EmployeeId))
            {
                temperatureRecord.RecordDate = DateTime.Now;
                _context.TemperatureRecords.Add(temperatureRecord);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<PaginatedList<TemperatureRecord>> GetTemperatureLogByEmployeeId(int PageIndex, int PageSize, Guid EmployeeId)
        {
            var source = _context.TemperatureRecords;
            var count = await source.CountAsync(log => log.EmployeeId==EmployeeId);
            var items = await source
                .Include(emp => emp.Employee)
                .Where(log => log.EmployeeId == EmployeeId)
                .Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            var output = new PaginatedList<TemperatureRecord>()
            {
                PageIndex = PageIndex,
                TotalRecords = count,
                Records = items
            };
            return output;
        }
    }
}

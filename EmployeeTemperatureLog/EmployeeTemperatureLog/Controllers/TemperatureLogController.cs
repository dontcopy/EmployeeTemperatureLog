using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeTemperatureLog.Data.TemperatureLogRepository;
using EmployeeTemperatureLog.Dtos;
using EmployeeTemperatureLog.Models;
using EmployeeTemperatureLog.Models.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;

namespace EmployeeTemperatureLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureLogController : ControllerBase
    {
        private readonly ITemperatureLogRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<TemperatureLogController> _logger;
        public TemperatureLogController(ITemperatureLogRepository repository,IMapper mapper, ILogger<TemperatureLogController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("AddRecord")]
        public ActionResult AddTemperatureRecord(NewTemperatureRecord newTemperatureRecord)
        {
            _logger.LogInformation(MethodBase.GetCurrentMethod().Name + " called");
            try
            {
                var newRecord = _mapper.Map<TemperatureRecord>(newTemperatureRecord);
                if (_repository.AddTemperatureLog(newRecord).Result)
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return NotFound();
        }

        [HttpGet("GetRecordsByTemperature/{PageIndex}/{PageSize}/{StartTemp}/{EndTemp}")]
        public ActionResult<Result<PaginatedList<TemperatureLogView>>> GetRecordsByTemperature(int PageSize, int PageIndex,double StartTemp,double EndTemp)
        {
            _logger.LogInformation(MethodBase.GetCurrentMethod().Name + " called");
            try
            {
                if (PageSize == 0 || PageIndex == 0||StartTemp==0||EndTemp==0)
                return NotFound();
                var tempRecords = _repository.GetTemperatureLogByTemperatureRange(PageIndex, PageSize,StartTemp,EndTemp).Result;
                if (tempRecords.TotalRecords == 0)
                    return NotFound();

                var output = new Result<PaginatedList<TemperatureLogView>>()
                {
                    Data = new PaginatedList<TemperatureLogView>()
                    {
                        PageIndex = PageIndex,
                        TotalRecords = tempRecords.TotalRecords,
                        Records = _mapper.Map<IEnumerable<TemperatureLogView>>(tempRecords.Records),
                    },
                    Message = "Request Success"
                };

                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return NotFound();
        }

        [HttpGet("GetRecordsByDate/{PageIndex}/{PageSize}/{StartDate}/{EndDate}")]
        public ActionResult<Result<PaginatedList<TemperatureLogView>>> GetRecordsByDate(int PageSize, int PageIndex, DateTime StartDate, DateTime EndDate)
        {
            _logger.LogInformation(MethodBase.GetCurrentMethod().Name + " called");
            try
            {
                if (PageSize == 0 || PageIndex == 0)
                return NotFound();
                 var tempRecords = _repository.GetTemperatureLogByDateRange(PageIndex, PageSize, StartDate, EndDate).Result;
                if (tempRecords.TotalRecords == 0)
                    return NotFound();

                var output = new Result<PaginatedList<TemperatureLogView>>()
                {
                    Data = new PaginatedList<TemperatureLogView>()
                    {
                        PageIndex = PageIndex,
                        TotalRecords = tempRecords.TotalRecords,
                        Records = _mapper.Map<IEnumerable<TemperatureLogView>>(tempRecords.Records),
                    },
                    Message = "Request Success"
                };

                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return NotFound();
        }
        [HttpGet("GetRecordsByEmployeeId/{PageIndex}/{PageSize}/{EmployeeId}")]
        public ActionResult<Result<PaginatedList<TemperatureLogView>>> GetRecordsByDate(int PageSize, int PageIndex, Guid EmployeeId)
        {
            _logger.LogInformation(MethodBase.GetCurrentMethod().Name + " called");
            try
            {
                if (PageSize == 0 || PageIndex == 0)
                return NotFound();
                var tempRecords = _repository.GetTemperatureLogByEmployeeId(PageIndex, PageSize,  EmployeeId).Result;
                if (tempRecords.TotalRecords == 0)
                    return NotFound();

                var output = new Result<PaginatedList<TemperatureLogView>>()
                {
                    Data = new PaginatedList<TemperatureLogView>()
                    {
                        PageIndex = PageIndex,
                        TotalRecords = tempRecords.TotalRecords,
                        Records = _mapper.Map<IEnumerable<TemperatureLogView>>(tempRecords.Records),
                    },
                    Message = "Request Success"
                };

                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return NotFound();
        }
    }
}

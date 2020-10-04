using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeTemperatureLog.Data.EmployeeRepository;
using EmployeeTemperatureLog.Dtos;
using EmployeeTemperatureLog.Models;
using EmployeeTemperatureLog.Models.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeTemperatureLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeRepository repository, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{Id}", Name = "GetEmployeeById")]
        public ActionResult<Result<EmployeeView>> GetEmployeeById(Guid Id)
        {
            _logger.LogInformation(MethodBase.GetCurrentMethod().Name + " called");
            try
            {
                var employee = _repository.GetEmployee(Id).Result;
                if (employee == null)
                    return NotFound();
                var output = new Result<EmployeeView>()
                {
                    Data = _mapper.Map<EmployeeView>(employee),
                    Message = "Request Success"
                };
                return Ok(output);
            }catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return NotFound();
        }
        [HttpPost("CreateEmployee")]
        public ActionResult AddEmployee(CreateEmployee CreatedEmployee)
        {
            _logger.LogInformation(MethodBase.GetCurrentMethod().Name + " called");
            try
            {
                var NewEmployee = _mapper.Map<Employee>(CreatedEmployee);
                var EmployeeId = _repository.AddEmployee(NewEmployee).Result;
                var output = new Result<Guid>()
                {
                Data = EmployeeId,
                Message = "Generated Employee Id"
                };
                return CreatedAtRoute(nameof(GetEmployeeById), new { Id = output.Data }, output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return NotFound();
        }

        [HttpPut("UpdateEmployee")]
        public ActionResult UpdateEmployee(UpdateEmployee UpdatedEmployee)
        {
            _logger.LogInformation(MethodBase.GetCurrentMethod().Name + " called");
            try
            {
                var ModifiedEmployee = _mapper.Map<Employee>(UpdatedEmployee);
                var EmployeeId = _repository.UpdateEmployee(ModifiedEmployee).Result;
                if (EmployeeId == null)
                return NotFound();
                var output = new Result<Guid>()
                {
                    Data = EmployeeId,
                    Message = "Updated Employee Id"
                };
                return CreatedAtRoute(nameof(GetEmployeeById), new { Id = output.Data }, output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return NotFound();
        }

        [HttpGet("GetEmployees/{PageIndex}/{PageSize}")]
        public ActionResult<Result<PaginatedList<EmployeeView>>> GetEmployees(int PageSize, int PageIndex)
        {
            _logger.LogInformation(MethodBase.GetCurrentMethod().Name + " called");
            try
            {
                if (PageSize == 0|| PageIndex==0)
                    return NotFound();
                var employees = _repository.GetAllEmployees(PageIndex, PageSize).Result;
                if (employees.TotalRecords == 0)
                    return NotFound();

                var output = new Result<PaginatedList<EmployeeView>>()
                {
                    Data = new PaginatedList<EmployeeView>()
                    {
                        PageIndex = PageIndex,
                        TotalRecords = employees.TotalRecords,
                        Records = _mapper.Map<IEnumerable<EmployeeView>>(employees.Records),
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

        [HttpGet("GetEmployeeByFirstName/{Firstname}")]
        public ActionResult<Result<IEnumerable<EmployeeView>>> GetEmployeeByFirstName(string Firstname)
        {
            _logger.LogInformation(MethodBase.GetCurrentMethod().Name + " called");
            try
            {
                var employees=_repository.GetEmployeeByFirstName(Firstname).Result;
                if (employees == null)
                    return NotFound();
                var output = new Result<IEnumerable<EmployeeView>>()
                {
                    Data = _mapper.Map< IEnumerable<EmployeeView>>(employees),
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

        [HttpGet("GetEmployeeByLastName/{Lastname}")]
        public ActionResult<Result<IEnumerable<EmployeeView>>> GetEmployeeByLastName(string Lastname)
        {
            _logger.LogInformation(MethodBase.GetCurrentMethod().Name + " called");
            try
            {
                var employees = _repository.GetEmployeeByLastName(Lastname).Result;
                if (employees == null)
                    return NotFound();
                var output = new Result<IEnumerable<EmployeeView>>()
                {
                    Data = _mapper.Map<IEnumerable<EmployeeView>>(employees),
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

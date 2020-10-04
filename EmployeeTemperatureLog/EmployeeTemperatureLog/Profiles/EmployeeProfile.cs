using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeTemperatureLog.Dtos;
using EmployeeTemperatureLog.Models;

namespace EmployeeTemperatureLog.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeView>();
            CreateMap<CreateEmployee, Employee>();
            CreateMap<UpdateEmployee, Employee>();
        }
    }
}

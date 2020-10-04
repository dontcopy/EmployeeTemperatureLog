using AutoMapper;
using EmployeeTemperatureLog.Dtos;
using EmployeeTemperatureLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTemperatureLog.Profiles
{
    public class TemperatureLogProfile:Profile
    {
        public TemperatureLogProfile()
        {
            CreateMap<NewTemperatureRecord,TemperatureRecord>();
            CreateMap<TemperatureRecord, TemperatureLogView>()
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.Employee.FirstName + " " + s.Employee.LastName));
        }
    }
}

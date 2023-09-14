using CineFlex.Application.Interfaces.Managers;
using CineFlex.Domain.Interfaces.Repositories;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Managers
{
    public class EmployeeManager : BaseManager<Employee>, IEmployeeManager
    {
        IEmployeeRepository _employeeRep;

        public EmployeeManager(IEmployeeRepository employeeRep) : base(employeeRep)
        {
            _employeeRep = employeeRep;
        }
    }
}